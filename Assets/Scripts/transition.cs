using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class transition : MonoBehaviour
{
    public float subir, velo;
    // Start is called before the first frame update
    void Start()
    {
        subir = -1130.7f;
        velo = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        subir += velo;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, subir);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            velo = 1.5f;
        }
        else
        {
            velo = 0.2f;
        }

        if(subir >= 1130.7 || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Fase 1 - Cidade");
        }
    }
}
