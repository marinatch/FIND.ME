using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public CharacterController control;
    private Vector3 moveDir;
    public float speedWalk, speedRun, speedRot, gravity, jumpForce;
    public int levelToLoad;

    public Animator anim;

    private float animSpeed;
    private int score;
    public Text scoreText;

    public GameObject winText;
    public bool youWin;
    public float winCounter;
    public float winWaitTime;



    void Start()
    {
        youWin = false;
    }

   
    void Update()
    {
        if (control.isGrounded)
        {
            moveDir = new Vector3(0, moveDir.y, Input.GetAxis("Vertical"));
            //convertir los ejes GLOBALES a ejes LOCALES
            moveDir = transform.TransformDirection(moveDir);
            //para rotar
            transform.Rotate(Vector3.up * speedRot * Input.GetAxis("Horizontal") * Time.deltaTime);

            //si mantienes pulsado el LeftShift corres
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animSpeed = Mathf.MoveTowards(animSpeed, Input.GetAxis("Vertical"), 2 * Time.deltaTime);
                anim.SetFloat("Blend", animSpeed);
                moveDir.x *= speedRun;
                moveDir.z *= speedRun;
            }
            //en caso que no, caminas
            else
            {
                animSpeed = Mathf.MoveTowards(animSpeed, Input.GetAxis("Vertical") / 2, 2 * Time.deltaTime);
                anim.SetFloat("Blend", animSpeed);
                moveDir.x *= speedWalk;
                moveDir.z *= speedWalk;
            }
            //Crowl
            if(Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("Crowl");
            }
            //saltar
            if(Input.GetButtonDown("Jump"))
            {
                moveDir.y = jumpForce;
            }

        }
        //cambiar el animacion al animacion de saltar
        anim.SetBool("Grounded", control.isGrounded);
        //aplicar la gravidad
        moveDir.y -= gravity * Time.deltaTime;
        //Aplicar todo el movimiento al personaje
        control.Move(moveDir * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        /*var item = other.GetComponent<Item>();
        if (item)
        {
            score++;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }*/

        if(other.tag== "Item")
        {
            score++;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
        if (other.tag == "Card")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Dead")
        {
            SceneManager.LoadScene(2);
        }
        if(other.tag == "Ship")
        {
            YouWin();
        }
    }

    public void YouWin()
    {
        // youWin = true;
        winText.SetActive(true);
        Time.timeScale = 0;
        youWin = true;
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
