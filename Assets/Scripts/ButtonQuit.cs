using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuit : MonoBehaviour
{
    // Start is called before the first frame update
    public void OutOfGame()
    {
        Application.Quit();
    }
}
