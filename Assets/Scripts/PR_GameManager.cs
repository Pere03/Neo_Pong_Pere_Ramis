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

    public bool ReturnGame;

    public GameObject Pause;

    public AudioClip PauseS;
    public AudioClip Resume;
    public AudioSource aSource;

    public GameObject Music;
    public AudioSource Mus;


    void Start()
    {
        Mus = Music.GetComponent<AudioSource>();

        aSource = GetComponent<AudioSource>();

        //Time.timeScale = 0;
        ReturnGame = false;
        Score_Player1 = 0;
        Score_Player2 = 0;

        Pause.SetActive(false);
    }

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
            SceneManager.LoadScene("PR_Win_Player1");
        }
        else
        {
            if (timeValue == 0 && Score_Player1 < Score_Player2)
            {
                SceneManager.LoadScene("PR_Win_Player2");
            }
        }

        if (Score_Player1 >= MaxScore)
        {
            SceneManager.LoadScene("PR_Win_Player1");
        }

        if (Score_Player2 >= MaxScore)
        {
            SceneManager.LoadScene("PR_Win_Player2");
        }

        if (timeValue == 0 && Score_Player1 == Score_Player2)
        {
            SceneManager.LoadScene(6);
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
        Mus.Pause();
        aSource.PlayOneShot(PauseS);
        Pause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Mus.Play();
        aSource.PlayOneShot(Resume);
        Time.timeScale = 1;
        Pause.SetActive(false); ;
    }

    public void BackMenu(int sceneID)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PR_MainMenu");
    }
}
