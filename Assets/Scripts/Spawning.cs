using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject thing;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameObject enemy = Instantiate(thing, spawnPoint.position, spawnPoint.rotation);
            Destroy(enemy, 15f);
        }

    }

}
