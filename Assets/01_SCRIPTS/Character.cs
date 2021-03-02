using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private bool monstreEtat = false;
    public Vector3 mouvement;

    public float speed;
    private float saut;
    private float masse;
    private float gravity;
    private float energie = 0;
    public float increment = 0;
    private float pose = 1;
    public bool jumping = false;
    private bool canTrans = true;

    public float speedF;
    public float sautF;
    public float masseF;
    public float gravityF;

    public float speedM;
    public float sautM;
    public float masseM;
    public float gravityM;

    private GameObject character;
    private CharacterController controller;
    public CameraFollow cam;
    public RectTransform curseur;
    private Vector2 xOffsetCurseur;

    public GameObject gbF;
    public GameObject gbM;

    private float[] fille;
    private float[] monstre;

    /////////////////////////////////////////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        fille = new float[4] { speedF, sautF, masseF, gravityF };
        monstre = new float[4] { speedM, sautM, masseM, gravityM };
        ChangeGB(gbF, 0, fille);
        xOffsetCurseur = curseur.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        mouvement.x = x * speed;

        if (controller.isGrounded && mouvement.y < 0)
        {
            mouvement.y = masse;
        }

        Transformation();

        if (jumping)
        {
            EndJump();
        }

        Rotate();
        Jump();

        if (canTrans)
        {
            Energie();
        }

        mouvement.y += gravity * Time.deltaTime;
        controller.Move(mouvement * Time.deltaTime);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////

    void Transformation()
    {
        if (Input.GetButtonDown("Transformation") && !monstreEtat)
        {
            ChangeGB(gbM, 1.3f, monstre);
            monstreEtat = true;
            energie = -0.2f;
            if(pose>0)
            {
                pose *= -1;
            }
            
        }
        else if (Input.GetButtonDown("Transformation") && monstreEtat)
        {
            ChangeGB(gbF, -0.6f, fille);
            monstreEtat = false;
            energie = 0.2f;
            if (pose < 0)
            {
                pose *= -1;
            }
        }
    }

    void ChangeGB(GameObject gb, float decalage, float[] stats)
    {
        Vector3 spawn;

        if (!character)
        {
            spawn = transform.position + new Vector3(0, decalage, 0);
        }
        else
        {
            spawn = character.transform.position + new Vector3(0, decalage, 0);
        }

        Destroy(character);
        character = Instantiate(gb, spawn, Quaternion.identity, transform);
        controller = character.GetComponent<CharacterController>();
        cam.joueur = character.transform;
        speed = stats[0];
        saut = stats[1];
        masse = stats[2];
        gravity = stats[3];
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            mouvement.y = Mathf.Sqrt(saut * -2 * gravity);
            jumping = true;
        }
    }

    public void CancelJump()
    {
        mouvement.y = gravity * Time.deltaTime;
    }

    public void EndJump()
    {
        if (controller.isGrounded)
        {
            this.jumping = false;
        }
    }

    void Rotate()
    {
        if (cam.droite && mouvement.x < 0)
        {
            cam.droite = false;
            character.transform.Rotate(0, 180, 0);
        }
        else if (!cam.droite && mouvement.x > 0)
        {
            cam.droite = true;
            character.transform.Rotate(0, -180, 0);
        }
    }

    void Energie()
    {
        energie += increment * pose;
        if (energie >= 1)
        {
            pose *= -1;
        }
        else if (energie <= -1)
        {
            pose *= -1;
        }

        //energie = Mathf.Sin(0.5f*Time.time + Mathf.PI/4);
        Debug.Log("energie = " + energie);
        Vector2 move = new Vector2(energie, 0);
        curseur.anchoredPosition = xOffsetCurseur + 75 * move;

        if (energie < 0 && !monstreEtat)
        {
            ChangeGB(gbM, 1.3f, monstre);
            monstreEtat = true;
            
        }
        else if (energie > 0 && monstreEtat)
        {
            ChangeGB(gbF, -0.6f, fille);
            monstreEtat = false;
            
        }
    }
}
