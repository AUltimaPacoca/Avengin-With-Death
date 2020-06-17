using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sons : MonoBehaviour
{
    public int somAleatorio;
    public float tempoPasso, tempoSom, tempoReload, MaxTempoReload;
    private AudioSource source;
    public AudioClip somDePassoAudio, somDeTiroAudio, somDeReloadAudio, somDeZumbiAudio, somDeZumbiAudio2, somDeZumbiAudio3, somDeHPUPAudio, somDeMunicaoUPAudio;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        tempoPasso = 40;
    }

    // Update is called once per frame
    void Update()
    {
        tempoSom += 1;
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && tempoSom >= tempoPasso)
        {
            source.PlayOneShot(somDePassoAudio);
            tempoSom = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            tempoPasso = 60f;
        }
        else
        {
            tempoPasso = 30f;
        }
    }

    public void SomDeTiro()
    {
        source.PlayOneShot(somDeTiroAudio);
    }

    public void SomDeReload()
    {
        source.PlayOneShot(somDeReloadAudio, 0.08f);
    }
    public void SomDeZumbi()
    {
        somAleatorio = Random.Range(1, 3);
        if (somAleatorio == 1)
        {
            source.PlayOneShot(somDeZumbiAudio);
        }
        if (somAleatorio == 2)
        {
            source.PlayOneShot(somDeZumbiAudio2);
        }
        if (somAleatorio == 3)
        {
            source.PlayOneShot(somDeZumbiAudio3);
        }

    }
    public void SomDeHPUP()
    {
        source.PlayOneShot(somDeHPUPAudio);
    }
    public void SomDeMunicaoUP()
    {
        source.PlayOneShot(somDeMunicaoUPAudio);
    }
}
