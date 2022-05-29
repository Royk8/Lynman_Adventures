using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject knot, blade, burnt, bigSpider, deadSpider;
    public PlayerMovement player;
    public Animator anima;
    private bool fall = false;
    public AudioSource cut, scream, soundTrack;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            knot.SetActive(false);
            burnt.SetActive(true);
            //fall = true;
            blade.SetActive(true);
            bigSpider.SetActive(false);
            deadSpider.SetActive(true);
            player.normalMove = false;
            anima.SetBool("Walk", true);
            cut.PlayDelayed(0.5f);
            scream.PlayDelayed(1f);
            soundTrack.Stop();
        }
    }

    /*private void FixedUpdate()
    {
        if(fall) blade.GetComponent<Rigidbody2D>().velocity = Vector2.down * 20f;
    }*/
}
