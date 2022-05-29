using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public float velocidad;
    public bool alterMove, goUp = false, coin;
    public int coinValue;
    public CoinCounter counter;

    void Start()
    {
        velocidad = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 diagonalArriba = Quaternion.AngleAxis(-45.0f,Vector3.forward)*Vector3.left;
        Vector3 diagonalAbajo = Quaternion.AngleAxis(45.0f, Vector3.forward) * Vector3.left;
        if (!alterMove) this.transform.position = this.transform.position + (Vector3.left) * velocidad * Time.deltaTime;
        else
        {
            if (transform.position.y > 7) goUp = false;
            if (transform.position.y < 1) goUp = true;
            if (goUp)
            {
                transform.position += diagonalArriba * velocidad * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, -45);
            }
            else
            {
                transform.position += diagonalAbajo * velocidad * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Projectile")
        {
            if (coin) counter.coinCounter += coinValue;
        }
    }
}
