using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject followPlayer, lockPoint;
    public Vector2 minCam, maxCam;
    public float smoothTime, reachFloorTime, lockWait = 1.0f, moveCamera;
    private WaitForSeconds wait;
    public bool lockCamera;

    private Vector2 velocity;

    private void Update()
    {
        if (followPlayer.transform.position.y == 2) reachFloorTime = Time.time;
    }

    void FixedUpdate()
    {
        float posX;
        if (!lockCamera)
        {
            posX = followPlayer.transform.position.x;
        }
        else
        {
            posX = lockPoint.transform.position.x;
        }
        float posY = Mathf.SmoothDamp(this.transform.position.y, followPlayer.transform.position.y, ref velocity.y, smoothTime);
            if (followPlayer.transform.position.y > moveCamera)
            {
                maxCam.y += 10;
            }
            if (followPlayer.transform.position.y < 2 && Time.time > reachFloorTime + lockWait)
            {
                maxCam.y = 6;
            }
            transform.position = new Vector3(Mathf.Clamp(posX, minCam.x, maxCam.x),
                Mathf.Clamp(posY, minCam.y, maxCam.y), transform.position.z);
        
    }
}
