using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruitveis : MonoBehaviour
{
    public float vida;
    public List<GameObject> Partes = new List<GameObject>();
    private BoxCollider bc;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    public void tomarDano(float i)
    {
        vida -= i;

        if (vida <= 0)
        {
            destruir();
        }
    }
    public void destruir()
    {
        for (int i = 0; i < Partes.Count; i++)
        {
            Partes[i].AddComponent<Rigidbody>();
            Rigidbody rb = Partes[i].GetComponent<Rigidbody>();
            float x = Random.Range(-500, 500);
            float y = Random.Range(0, 500);
            float z = Random.Range(-500, 500);
            rb.AddForce(new Vector3(x, y, z));
        }
        bc.isTrigger = true;
        Destroy(this);
    }
}