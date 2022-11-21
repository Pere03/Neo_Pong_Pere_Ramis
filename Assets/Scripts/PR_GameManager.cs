using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PR_GameManager : MonoBehaviour
{
    public TextMeshProUGUI Counter_Player1;
    public TextMeshProUGUI Counter_Player2;

    public int Score_Player1;
    public int Score_Player2;
    public int MaxScore;

    public TextMeshProUGUI time;
    public float timeValue;

    public TextMeshProUGUI timePause;
    public float timePauseValue;

    public bool ReturnGame;

    public int time_Pause;
    void Start()
    {
        time_Pause = 5;
        ReturnGame = false;
        Score_Player1 = 0;
        Score_Player2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        if(ReturnGame == true)
        {
            if (timePauseValue > 0)
            {
                timePauseValue -= Time.deltaTime;
            }
            else
            {
                timePauseValue = 0;
            }
        }

        DisplayTime(timeValue);

        DisplayTime(timePauseValue);


        if (timeValue == 0 && Score_Player1 > Score_Player2)
        {
            SceneManager.LoadSceneAsync(5);
        }
        else
        {
            if (timeValue == 0 && Score_Player1 < Score_Player2)
            {
                SceneManager.LoadSceneAsync(4);
            }
        }

        if (Score_Player1 >= MaxScore)
        {
            SceneManager.LoadSceneAsync(5);
        }

        if (Score_Player2 >= MaxScore)
        {
            SceneManager.LoadSceneAsync(4);
        }

        if (timeValue == 0 && Score_Player1 == Score_Player2)
        {
            SceneManager.LoadSceneAsync(6);
        }

        if (Time.timeScale == 1)
        {
            ReturnGame = false;
        }
    }

    
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayTimePause(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timePause.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddPoint_Player1()
    {
        Score_Player1++;

        Counter_Player1.text = Score_Player1.ToString();
    }

    public void AddPoint_Player2()
    {
        Score_Player2++;

        Counter_Player2.text = Score_Player2.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        ReturnGame = true;
        if(timePauseValue == 0)
        {
            Time.timeScale = 1;
            timePauseValue = time_Pause;
        }
    }
}
