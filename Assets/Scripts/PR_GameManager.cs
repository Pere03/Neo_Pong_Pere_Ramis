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

        //With this we put the condition that if player 1 or player 2 has more points than the other and the time is up, it will take us to the victory screen of the respective player.
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
        //If one of the 2 players reaches the maximum number of points, victory will be awarded.
        if (Score_Player1 >= MaxScore)
        {
            SceneManager.LoadScene("PR_Win_Player1");
        }

        if (Score_Player2 >= MaxScore)
        {
            SceneManager.LoadScene("PR_Win_Player2");
        }

        //If time runs out, and if player 1 and player 2 have the same number of points, it will end in a tie.
        if (timeValue == 0 && Score_Player1 == Score_Player2)
        {
            SceneManager.LoadScene("PR_Tie");
        }
    }

    //With this we can show on the screen that the counter is like a real one (with hours, minutes and seconds).
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

    //If the Pause button is pressed, the time will stop, the background music will stop, and the pause panel will be activated.
    public void PauseGame()
    {
        Mus.Pause();
        aSource.PlayOneShot(PauseS);
        Pause.SetActive(true);
        Time.timeScale = 0f;
    }

    //And if we press the Resume Game button, the background music will be activated again and the time will resume.
    public void ResumeGame()
    {
        Mus.Play();
        aSource.PlayOneShot(Resume);
        Time.timeScale = 1;
        Pause.SetActive(false); ;
    }

    //If we press the "BackMenu" button, we will return to the home screen.
    public void BackMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PR_MainMenu");
    }
}
