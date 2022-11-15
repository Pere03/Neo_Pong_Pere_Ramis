using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PR_GameManager_Madness : MonoBehaviour
{
    public TextMeshProUGUI Counter_Player1;
    public TextMeshProUGUI Counter_Player2;

    public int Score_Player1;
    public int Score_Player2;

    public TextMeshProUGUI time;
    public float timeValue = 100;

    void Start()
    {
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

        DisplayTime(timeValue);

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

        if (Score_Player1 >= 99)
        {
            SceneManager.LoadSceneAsync(5);
        }

        if (Score_Player2 >= 99)
        {
            SceneManager.LoadSceneAsync(4);
        }

        if (timeValue == 0 && Score_Player1 == Score_Player2)
        {
            SceneManager.LoadSceneAsync(6);
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
}
