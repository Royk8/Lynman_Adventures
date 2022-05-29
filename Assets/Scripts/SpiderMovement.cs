using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float velocidad;
    public bool death=false, coin;
    public int coinValue;
    //public Animation disappear;
    void Start()
    {
        velocidad = 12;
    }

    void FixedUpdate()
    {
        this.transform.position = this.transform.position + (Vector3.left) * velocidad * Time.deltaTime;
    }

    private void OnDestroy()
    {
        death = true;
    }


}
