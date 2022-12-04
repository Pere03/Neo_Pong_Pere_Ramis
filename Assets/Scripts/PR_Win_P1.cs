using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PR_Win_P1 : MonoBehaviour
{
    public static PR_Win_P1 sharedInstance;
    public float timeValue;
    public GameObject Button;
    public int Victoria;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        Button.SetActive(false);
        Victoria++;
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

        if (timeValue == 0)
        {
            Button.SetActive(true);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("PR_MainMenu");
    }

    //With this we do, that after having added a victory to player 1, we save this data in our data persistence.
    public void SaveUserOptions()
    {
        PR_DataPersistence.sharedInstance.Wins_P1 += Victoria;
        PR_DataPersistence.sharedInstance.Data();
    }
}
