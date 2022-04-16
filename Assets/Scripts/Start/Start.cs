using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    private string playScene = "Play";
    public void StartGame()
    {
        SceneManager.LoadScene(playScene);
    }
}
