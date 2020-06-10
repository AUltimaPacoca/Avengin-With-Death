using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luzes : MonoBehaviour
{
    public float contador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador += 1;
        if(contador >= 200)
        {
            contador = 0;
        }
        if (contador >= 0 && contador <= 50)
        {
            GetComponent<Light>().color = Color.red;
        }
        if (contador >= 51 && contador <= 100)
        {
            GetComponent<Light>().color = Color.blue;
        }
        if (contador >= 101 && contador <= 150)
        {
            GetComponent<Light>().color = Color.green;
        }
        if (contador >= 151 && contador <= 200)
        {
            GetComponent<Light>().color = Color.magenta;
        }
    }
}
