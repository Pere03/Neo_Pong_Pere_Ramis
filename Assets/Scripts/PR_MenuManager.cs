using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PR_MenuManager : MonoBehaviour
{
    public GameObject PlayPanel;
    public GameObject OptionsPanel;
    public GameObject ResultsPanel;

    void Start()
    {
        PlayPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        ResultsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
