using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextLevel;
    public CoinCounter coinCounter;
    public static int coinCarry;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            coinCarry = coinCounter.coinCounter;
            SceneManager.LoadScene(nextLevel);
        }
    }

    private void Start()
    {
        coinCounter.coinCounter += coinCarry;
    }
}
