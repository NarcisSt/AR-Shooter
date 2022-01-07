using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timerIsRunning = false;
    public int roomNumber;
    public Text timeText;

    private void Start()
    {
        // Starts the timer automatically
        if(timeRemaining == 0)
        {
            if (roomNumber == 1)
            {
                timeRemaining = 100;
            }
            else if (roomNumber == 2)
            {
                timeRemaining = 140;
            }
            else
            {
                timeRemaining = 60;
            }
        }
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(6);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
