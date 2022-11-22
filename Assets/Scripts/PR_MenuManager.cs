using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class PR_MenuManager : MonoBehaviour
{
    public GameObject PlayPanel;
    public GameObject OptionsPanel;
    public GameObject ResultsPanel;

    public int Wins_Player_1;
    public int Wins_Player_2;
    public TextMeshProUGUI Wins_p1_text;
    public TextMeshProUGUI Wins_p2_text;

    void Start()
    {
        LoadUserOptions();

        PlayPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        ResultsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SaveUserOptions();
    }

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

    public void PlayOpen()
    {
        PlayPanel.SetActive(true);
    }

    public void NormalMode()
    {
        SceneManager.LoadScene("PR_Normal_Game");

    }

    public void MadnessMode()
    {
        SceneManager.LoadScene("PR_Madness_Game"); 
    }

    public void QuickMode()
    {
        SceneManager.LoadScene("PR_Quick_Game"); 
    }

    public void PlayClose()
    {
        PlayPanel.SetActive(false);
    }

    public void OptionsOpen()
    {
        OptionsPanel.SetActive(true);
    }

    public void OptionsClose()
    {
        OptionsPanel.SetActive(false);
    }

    public void ResultsOpen()
    {
        ResultsPanel.SetActive(true);
    }

    public void ResultsClose()
    {
        ResultsPanel.SetActive(false);
    }

    
}
