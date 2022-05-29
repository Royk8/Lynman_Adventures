using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    Text text;
    public int coinCounter;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = coinCounter.ToString();
    }
}
