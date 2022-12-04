using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class PR_MenuManager : MonoBehaviour
{
    public GameObject PlayPanel;
    public GameObject ResultsPanel;

    public int Wins_Player_1;
    public int Wins_Player_2;
    public TextMeshProUGUI Wins_p1_text;
    public TextMeshProUGUI Wins_p2_text;

    public AudioClip EffectOk;
    public AudioClip EffectWClose;
    public AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        LoadUserOptions();

        PlayPanel.SetActive(false);
        ResultsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SaveUserOptions();
    }

    //With this we make sure to load the amount of victories of Player 1 and Player 2, and re-save it all the time, so we can have that persistence of data at all times.
    public void SaveUserOptions()
    {
        PR_DataPersistence.sharedInstance.Wins_P1 = Wins_Player_1;
        PR_DataPersistence.sharedInstance.Wins_P2 = Wins_Player_2;
        PR_DataPersistence.sharedInstance.Data();
    }
    public void LoadUserOptions()
    {
        Wins_Player_1 = PlayerPrefs.GetInt("WINS_PLAYER1");
        Wins_p1_text.text = Wins_Player_1.ToString();
        Wins_Player_2 = PlayerPrefs.GetInt("WINS_PLAYER2");
        Wins_p2_text.text = Wins_Player_2.ToString();
    }

    //With this we can load depending on which game mode we want, depending on which button we press.
    public void NormalMode()
    {
        aSource.PlayOneShot(EffectOk);
        SceneManager.LoadScene("PR_Normal_Game");
    }

    public void MadnessMode()
    {
        aSource.PlayOneShot(EffectOk);
        SceneManager.LoadScene("PR_Madness_Game"); 
    }

    public void QuickMode()
    {
        aSource.PlayOneShot(EffectOk);
        SceneManager.LoadScene("PR_Quick_Game"); 
    }

    //With this we make that depending on which button, close or open a menu, and also play a sound.
    public void PlayOpen()
    {
        aSource.PlayOneShot(EffectOk);
        PlayPanel.SetActive(true);
    }

    public void PlayClose()
    {
        aSource.PlayOneShot(EffectWClose);
        PlayPanel.SetActive(false);
    }

    public void ResultsOpen()
    {
        aSource.PlayOneShot(EffectOk);
        ResultsPanel.SetActive(true);
    }

    public void ResultsClose()
    {
        aSource.PlayOneShot(EffectWClose);
        ResultsPanel.SetActive(false);
    }

    
}
