using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    //configurações da arma     
    public float dano, alcance, firerate, esperarFirerate, camFov = 60;
    public Camera cam;
    public ParticleSystem sangueParticula, tiroParticula;
    public GameObject mao, sons;
    public bool segurando = false, podeAtirar = true;

    public int municaoAtual, municaoMaxima, municaoExtra, tempoRecarga, municaoRecarregar;

    public Text MunicaoText, municaoExtraText;
    
    void Update()
    {
        tempoRecarga += 1;
        //controles de tiro
        if (podeAtirar == true)
        {
            if (esperarFirerate < firerate)
            {
                esperarFirerate += 1;
            }
            if (Input.GetKey(KeyCode.Mouse0) && esperarFirerate == firerate && municaoAtual != 0)
            {
                Tiro();
                sons.GetComponent<Sons>().SomDeTiro();
                municaoAtual -= 1;
                GetComponent<Animator>().SetBool("estaAtirando", true);
                mao.GetComponent<Animator>().SetBool("estaAtirando", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("estaAtirando", false);
                mao.GetComponent<Animator>().SetBool("estaAtirando", false);
            }
        }

        //recarregar
        municaoRecarregar = municaoMaxima - municaoAtual;
        MunicaoText.text = municaoAtual + "/" + municaoMaxima;
        municaoExtraText.text = "" + municaoExtra;
        
        if ((Input.GetKeyDown(KeyCode.R) || municaoAtual == 0) && tempoRecarga >= 200 && municaoExtra != 0 && municaoAtual < municaoMaxima)
        {
            mao.GetComponent<Animator>().SetBool("estaRecarregando", true);
            GetComponent<Animator>().SetBool("estaRecarregando", true);
            sons.GetComponent<Sons>().SomDeReload();
            if (municaoRecarregar != 0 && municaoExtra != 0 && municaoExtra > municaoRecarregar)
            {
                municaoExtra = municaoExtra - municaoRecarregar;
                municaoAtual = municaoAtual + municaoRecarregar;
            }
            if (municaoRecarregar != 0 && municaoExtra != 0 && municaoExtra < municaoRecarregar)
            {
                municaoAtual = municaoAtual  + municaoExtra;
                municaoExtra = 0;
            }
            tempoRecarga = 0;
        }
        else
        {
            mao.GetComponent<Animator>().SetBool("estaRecarregando", false);
            GetComponent<Animator>().SetBool("estaRecarregando", false);
        }

        //mirar

        cam.GetComponent<Camera>().fieldOfView = camFov;
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if(camFov > 45)
            {
                camFov -= 1;
            }
            mao.GetComponent<Animator>().SetBool("estaMirando", true);
        }
        else
        {
            if(camFov < 60)
            {
                camFov += 1;
            }
            mao.GetComponent<Animator>().SetBool("estaMirando", false);
        }
        //animações
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            mao.GetComponent<Animator>().SetBool("estaCorrendo", true);
            podeAtirar = false;
        }
        else
        {
            mao.GetComponent<Animator>().SetBool("estaCorrendo", false);
            podeAtirar = true;
        }
    }

    void Tiro()
    {
        esperarFirerate = 0;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, alcance))
        {
            Inimigos inim = hit.transform.GetComponent<Inimigos>();
            if (inim != null)
            {
                inim.TomarDano();
            }
            if(hit.collider.gameObject.tag == "inimigos")
            {
               Instantiate(sangueParticula, hit.point + (hit.normal), Quaternion.FromToRotation(-Vector3.back, hit.normal));
            }
        }
        tiroParticula.Play();
    }
    public void PegarMunicao()
    {
        municaoExtra += 20;
    }
}