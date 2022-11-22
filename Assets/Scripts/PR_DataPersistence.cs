using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PR_DataPersistence : MonoBehaviour
{
    public static PR_DataPersistence sharedInstance;
    public int Wins_P1;
    public int Wins_P2;
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(sharedInstance);
        }
        else
        {
            Destroy(this);
        }
    }

    public void Data()
    {
        PlayerPrefs.SetInt("WINS_PLAYER1", Wins_P1);
        PlayerPrefs.SetInt("WINS_PLAYER2", Wins_P2);
    }
}
