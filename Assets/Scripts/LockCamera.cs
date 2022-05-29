using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    public CameraMovement cam;
    public BigSpider bigS;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            cam.lockCamera = true;
        }else if(collision.gameObject.tag == "Boss")
        {
            bigS.stop = true;
        }
    }
}
