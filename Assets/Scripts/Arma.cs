using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    //configurações da arma
    public float dano, alcance, firerate, esperarFirerate;
    public Camera cam;
    public ParticleSystem particulaDisparo;
    public GameObject impacto;
    public bool segurando = false;

    public int municaoAtual, municaoMaxima, municaoExtra, tempoRecarga, municaoRecarregar;

    public Text MunicaoText, municaoExtraText;

    void Start()
    {
        
    }

    void Update()
    {
        //controles de tiro
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            segurando = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            segurando = false;
        }
        if (segurando == true)
        {
            esperarFirerate += 1;
        }
        if(esperarFirerate > firerate && municaoAtual != 0)
        {
            Tiro();
            municaoAtual -= 1;
        }

        //recarregar
        municaoRecarregar = municaoMaxima - municaoAtual;
        MunicaoText.text = municaoAtual + "/" + municaoMaxima;
        municaoExtraText.text = "" + municaoExtra;

        if (Input.GetKeyDown(KeyCode.R) || municaoAtual == 0)
        {
            if(municaoRecarregar != 0 && municaoExtra != 0 && municaoExtra > municaoRecarregar)
            {
                municaoExtra = municaoExtra - municaoRecarregar;
                municaoAtual = municaoAtual + municaoRecarregar;
            }
            if(municaoRecarregar != 0 && municaoExtra != 0 && municaoExtra < municaoRecarregar)
            {
                municaoAtual = municaoAtual + municaoExtra;
                municaoExtra = 0;
            }
        }
        //log
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("A munição Atual é: " + municaoAtual);
            Debug.Log("A munição Maxima é: " + municaoMaxima);
            Debug.Log("A munição Extra é: " + municaoExtra);
        }
    }

    void Tiro()
    {
        esperarFirerate = 0;
        //particulaDisparo.Play();
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, alcance))
        {
            print("mirando em: " + hit.transform.name);


            destruitveis dest = hit.transform.GetComponent<destruitveis>();
            if(dest != null)
            {
                dest.tomarDano(dano);
            }

            //GameObject impactoOBJ = Instantiate(impacto, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
