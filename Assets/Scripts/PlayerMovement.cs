using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad, jumpForce, jumppForce, jumpTime, jumpCD=0.5f;
    public Animator Player;
    public int estadoMovimiento, coinCounter;
    public bool jump, piso, magic, normalMove, jumpp;
    public GameObject gameOver;
    private Rigidbody2D rigip;
    [HideInInspector]
    public float maxJump;
    

    void Start()
    {
        gameOver.SetActive(false);
        estadoMovimiento = 0;
        rigip = GetComponent<Rigidbody2D>();
        jumpForce = 30f;
        normalMove = true;
    }

    void Update()
    {
        if (rigip.velocity.y < -0.1) Player.SetBool("Fall", true);
        else Player.SetBool("Fall", false);

        Player.SetBool("onFloor", piso);
        if (piso)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Time.time > jumpTime + jumpCD)
                {
                    jump = true;
                    jumpTime = Time.time;
                }                    
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (Time.time > jumpTime + jumpCD)
                {
                    jumpp = true;
                    jumpTime = Time.time;
                }                    
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (maxJump > 0)
                {
                    jumpp = true;
                    maxJump -= Time.time;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        this.transform.position = this.transform.position + (Vector3.right * Input.GetAxis("Horizontal")) * velocidad * Time.deltaTime;
        /*if(normalMove) this.transform.position = this.transform.position + (Vector3.right) * velocidad * Time.deltaTime;
        else this.transform.position = this.transform.position + (Vector3.right) * 3 * Time.deltaTime;*/
        if (velocidad > 2)
        {
            estadoMovimiento = 1;
        }
        Player.SetInteger("Estado", estadoMovimiento);
        if (jump)
        {
            rigip.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
        if (jumpp)
        {
            rigip.AddForce(Vector2.up * jumppForce, ForceMode2D.Force);
            jumpp = false;
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor") piso = true;
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor") piso = false;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            gameOver.SetActive(true);
            gameObject.SetActive(false);
            Cursor.visible = true;
        }
    }

    public void saltar()
    {
        if (piso)
        {
            if (Time.time > jumpTime + jumpCD)
            {
                jump = true;
                jumpTime = Time.time;
            }
        }

        if (jump)
        {
            //rigip.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rigip.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            jump = false;
        }

    }

}
