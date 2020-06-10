using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Slider barraVida;
    public float speed, sensibility, jumpHeight, vida, dano, bateriaLanterna, gameOverVelo, gameOverEsqStart, gameOverDirStart;
    public bool enableMouse;
    public GameObject arma, lanterna, gameOverCanvas;
    public Text lantText;

    private Player5 playerConf;
    private Arma armaScript;

    void Start()
    {
        speed = 5f;
        sensibility = 3f;
        jumpHeight = 5f;
        enableMouse = true;
        playerConf = GetComponent<Player5>();
        armaScript = arma.GetComponent<Arma>();

        vida = 200f;
        bateriaLanterna = 100;
    }

    void Update()
    {
        //mouse
        if(enableMouse == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //movimento

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _MoveHorizontal = transform.right * _xMov;
        Vector3 _MoveVertical = transform.forward * _zMov;

        //Place Moviment
        Vector3 _velocity = (_MoveHorizontal + _MoveVertical).normalized * speed;
        playerConf.Move(_velocity);

        //rotation
        float _yMouse = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yMouse, 0f) * sensibility;
        
        if(enableMouse == true)
        {
            playerConf.rotate(_rotation);

            float _xMouse = Input.GetAxisRaw("Mouse Y");
            Vector3 _cameraRotation = new Vector3(_xMouse, 0f, 0f) * sensibility;
            
            if(enableMouse == true)
            {
                playerConf.camRotate(_cameraRotation);
            }

            if (Input.GetButton("Jump"))
            {
                playerConf.Jump(jumpHeight);
            }
        }

        //vida
        if(vida > 200)
        {
            vida = 200;
        }
        barraVida.value = vida;

        //lanterna
        if(lanterna != null && lantText != null)
        {
            lantText.text = bateriaLanterna.ToString("F0") + "% de bateria restando";
            if (Input.GetKey(KeyCode.Q) && bateriaLanterna >= 0)
            {
                lanterna.SetActive(true);
                lantText.gameObject.SetActive(true);
                bateriaLanterna -= 0.01f;
            }
            else
            {
                lanterna.SetActive(false);
                lantText.gameObject.SetActive(false);
                bateriaLanterna -= 0;
            }
            if (Input.GetKey(KeyCode.Q) && bateriaLanterna <= 0)
            {
                lantText.gameObject.SetActive(false);
                lantText.text = "Não há bateria";
            }
        }
    }

    public void TomarDano()
    {
            vida -= dano;
            if (vida <= 0)
            {
                GameOver();
            }
        }

    public void GameOver()
    {
        gameOverCanvas.GetComponent<Animator>().SetBool("gameOver", true);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "inimigos")
        {
            dano = collision.gameObject.GetComponent<Inimigos>().dano;
            print("o dano inimigo é de " + dano);
        }
        if (collision.gameObject.tag == "itemVida")
        {
            vida += 40;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "municao")
        {
            armaScript.PegarMunicao();
            Destroy(collision.gameObject);
        }
    }


}