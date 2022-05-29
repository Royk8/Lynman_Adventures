using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpider : MonoBehaviour
{
    private float velocidad = 12;
    public GameObject spider, alerta;
    public Transform spawnPoint;
    public Animator BigS;
    public AudioSource scream;
    public bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        BigS.SetInteger("Estado", 1);
    }

    private void FixedUpdate()
    {
        if(!stop) this.transform.position = this.transform.position + (Vector3.right) * velocidad * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Activador")
        {
            BigS.SetInteger("Estado", 2);
            alerta.SetActive(true);
            scream.Play();
        }
        if(col.gameObject.tag == "Posicion")
        {
            if (BigS.GetInteger("Estado") == 1) BigS.SetInteger("Estado", 0);
            else BigS.SetInteger("Estado", 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Activador")
        {
            SpawnSpider();
            alerta.SetActive(false);
            BigS.SetInteger("Estado", 1);
        }
    }

    private void SpawnSpider()
    {
        Instantiate(spider, spawnPoint.position, spawnPoint.rotation);
    }
}
