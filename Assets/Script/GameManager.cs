using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject WinningObject;
    public GameObject gameOver;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void Complited()
    {
        //Time.timeScale = 0;
        WinningObject.SetActive(true);
    }

    public void GameOver()
    {
        //Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1;
    }

    public void NextLevel()
    {
        //Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
        //Time.timeScale = 1;
    }
}
