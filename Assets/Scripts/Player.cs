using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velFrente, VelTras, VelGiro, pulo;
    public GameObject camControl;
    private float mouseX;
    public float sensibilidade = 2.0f;
    public bool noChao;

    void Start()
    {
        velFrente = 10;
        VelTras = 5;
        pulo = 5;
        noChao = false;
    }

    void Update()
    {
        //movimento
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, (velFrente * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, (-VelTras * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((-VelTras * Time.deltaTime), 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((VelTras * Time.deltaTime), 0, 0);
        }

        //pulo
        noChao = Physics.Raycast(transform.position, Vector3.down, 4.5f);
        Debug.Log(noChao);
        if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
        {
            GetComponent<Rigidbody>().AddForce(0, pulo, 0, ForceMode.Impulse);
        }

        //rotação
        mouseX += Input.GetAxis("Mouse X") * sensibilidade;
        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
}
