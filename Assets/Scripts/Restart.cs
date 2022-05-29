using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string level;

    public void restartScene()
    {
        SceneManager.LoadScene(level);
    }
}
