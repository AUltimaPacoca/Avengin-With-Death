using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public int contagemZumbis, trocaTextoSpcneon;
    public Text contagemZumbisText, spcneon;
    public GameObject contagemZumbisOBJ, proximaFaseOBJ;
    public string cenaAtual;

    private void Update()
    {
        if(contagemZumbisText != null && contagemZumbisOBJ != null)
        {
            contagemZumbis = GameObject.FindGameObjectsWithTag("inimigos").Length;
            contagemZumbisText.text = contagemZumbis.ToString();

            if (contagemZumbis <= 0)
            {
                contagemZumbisOBJ.SetActive(false);
                proximaFaseOBJ.SetActive(true);
            }
        }
        if(spcneon != null)
        {
            print(trocaTextoSpcneon);
            trocaTextoSpcneon += 1;
            if (trocaTextoSpcneon > 500 && trocaTextoSpcneon < 1000)
            {
                spcneon.text = "Eles não precisam ver ou ouvir você para saber que está aí";
            }
            if (trocaTextoSpcneon > 1000 && trocaTextoSpcneon < 1500)
            {
                spcneon.text = "Então não se preocupe se esconder ou fazer silencio";
            }
            if (trocaTextoSpcneon > 1500 && trocaTextoSpcneon < 2000)
            {
                spcneon.text = "Apenas corra";
            }
            if (trocaTextoSpcneon > 2500 && trocaTextoSpcneon < 3000)
            {
                spcneon.text = "Jaspy se encontra depois da ponte, em uma usina";
            }
            if (trocaTextoSpcneon > 3500 && trocaTextoSpcneon < 4000)
            {
                spcneon.text = "a entrada da ponte está bloqueada pelos lados";
            }
            if (trocaTextoSpcneon > 4500 && trocaTextoSpcneon < 5000)
            {
                spcneon.text = "o unico jeito de chegar lá é atraves do space neon";
            }
            if (trocaTextoSpcneon > 5500 && trocaTextoSpcneon < 6000)
            {
                spcneon.text = "é o unico lugar com uma luz brilhante e verde";
            }
            if (trocaTextoSpcneon > 6500 && trocaTextoSpcneon < 7000)
            {
                spcneon.text = "ache-o e entre la";
            }
            if(trocaTextoSpcneon > 7500)
            {
                Destroy(spcneon);
            }
        }
        if (Input.GetKey(KeyCode.T))
        {
            reloadFase();
        }
        if (Input.GetKey(KeyCode.G))
        {
            menu();
        }
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void reloadFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Fase1()
    {
        SceneManager.LoadScene("transition");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(contagemZumbis == 0)
        {
            SceneManager.LoadScene("Fase 3 - Usina");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Fase 2 - Balada");
    }
}
