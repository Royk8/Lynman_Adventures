using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject disappear;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            spark();
            BatMovement bat = col.gameObject.GetComponent<BatMovement>();
            if(bat != null)
                if (bat.coin)
                {
                    GameObject cc = GameObject.Find("CoinCounterText");
                    CoinCounter coinC = cc.GetComponent<CoinCounter>();
                    coinC.coinCounter += bat.coinValue;
                }
            col.gameObject.SetActive(false);
            Destroy(col.gameObject,1f) ;
            Destroy(gameObject);
            
        }
        else if (col.gameObject.tag == "Floor") Destroy(gameObject);
        else if( col.gameObject.tag == "Boss")
        {
            spark();
            Destroy(gameObject);
        }      

        
    }
    private void spark()
    {
        GameObject puff = Instantiate(disappear) as GameObject;
        puff.transform.position = this.transform.position;
        puff.transform.rotation = this.transform.rotation;
        Destroy(puff, 1.0f);
    }
}
