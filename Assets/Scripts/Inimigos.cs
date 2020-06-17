using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public Arma armaScript;
    public string nome;
    public float vida, velocidade, ataque, dano, passo, tempoParaDano, tempoParaSom, tempoAleatorio, posY, rotX;
    public bool modoJaspy, seguir;
    public GameObject sons, telaDeVitoria;
    Transform alvo;
    public Slider vidaJaspy;

    private void Start()
    {
        posY = transform.position.y;
        rotX = transform.rotation.x;
        alvo = GameObject.Find("Player").transform;
        seguir = true;

        if (modoJaspy == true)
        {
            nome = "Jaspy";
            vida = 600;
            velocidade = 3.5f;
            dano = 20;
        }
        else
        {
            nome = "Zumbi";
            vida = 50;
            velocidade = 2;
            dano = 5;
        }
        
        tempoParaDano = 80f;
    }

    private void Update()
    {
        tempoParaDano += 1;

        if (tempoParaDano >= 200)
        {
            seguir = true;
        }

        if (vidaJaspy != null)
        {
            vidaJaspy.value = vida;
        }

        if(seguir == true)
        {
            passo = velocidade * Time.deltaTime;
        }
        else
        {
            passo = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, alvo.position, passo);
        transform.LookAt(alvo);

        //som
        tempoParaSom += 1;
        if(tempoParaSom > tempoAleatorio)
        {
            tempoAleatorio = Random.Range(200, 400);
            sons.GetComponent<Sons>().SomDeZumbi();
            tempoParaSom = 0;
        }

        //travar inimigos em y
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        transform.eulerAngles = new Vector2(rotX, transform.eulerAngles.y);
        
    }

    public void TomarDano()
    {
        vida -= armaScript.dano;
        if (vida <= 0)
        {
            Destruir();
            if(vidaJaspy != null)
            {
                Destroy(vidaJaspy.gameObject);
            }
        }
    }

    public void Destruir()
    {
        Destroy(gameObject);
        if(this.nome == "Jaspy")
        {
            telaDeVitoria.GetComponent<Animator>().SetBool("venceu", true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player" && tempoParaDano >= 300)
        {
            //dano
            collision.gameObject.GetComponent<PlayerControler>().TomarDano();
            tempoParaDano = 0f;

            //movimento inimigo
            seguir = false;
        }
    }
}