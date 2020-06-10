using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public int tempo, tempoParaDestruir;
    // Start is called before the first frame update
    void Start()
    {
        tempoParaDestruir = 50;
    }

    // Update is called once per frame
    void Update()
    {
        tempo += 1;
        if(tempo >= tempoParaDestruir)
        {
            Destroy(gameObject);
        }
    }
}
