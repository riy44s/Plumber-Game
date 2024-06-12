using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float totalTime = 60f; 


    private float currentTime;
    private bool timerReachedZero = false;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (timerReachedZero)
            return;

        currentTime -= Time.deltaTime;


        currentTime = Mathf.Clamp(currentTime, 0f, totalTime);


        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);


        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (currentTime <= 0f)
        {
            currentTime = 0f;
            timerText.text = "00:00";
            timerReachedZero = true;

            GameManager.instance.GameOver();

        }
    }
}