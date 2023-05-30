using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void IsGameOver()
    { if(SceneManager.GetActiveScene().buildIndex == 2)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -4);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }
}
