using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   
    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void StartGame(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
}
