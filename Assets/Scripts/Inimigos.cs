using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public Arma armaScript;
    public string nome;
    public float vida, velocidade, ataque, dano, passo, tempoParaDano;
    public bool modoJaspy;
    public GameObject sons;
    Transform alvo;

    private void Start()
    {
        alvo = GameObject.Find("Player").transform;


        if (modoJaspy == true)
        {
            nome = "Jaspy";
            vida = 250;
            velocidade = 2.5f;
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
        sons.GetComponent<Sons>().SomDeZumbi();
        passo = velocidade * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, alvo.position, passo);
        transform.LookAt(alvo);
    }

    public void TomarDano()
    {
        vida -= armaScript.dano;
        if (vida <= 0)
        {
            Destruir();
        }
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player" && tempoParaDano >= 80)
        {
            collision.gameObject.GetComponent<PlayerControler>().TomarDano();
            tempoParaDano = 0f;
        }
        else
        {
            tempoParaDano += 1;
        }
    }
}