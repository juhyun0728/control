using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public GameObject popUp_clear, popUp_Notice;
    int stageAmount, currentStage, nextStage;
    public bool isClear;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        stageAmount = 4 ;
        Time.timeScale = 1;
        isClear = false;
    }

    private void Update()
    {
        if (isClear == true)
        {
            GameClear();
        }
    }

    void GameClear()
    {
        Time.timeScale = 0;
        for (int i = 1; i <= stageAmount; i++)
        {
            if (SceneManager.GetActiveScene().name == "GameScene " + i)
            {
                currentStage = i;
                nextStage = currentStage + 1;

                if (nextStage <= stageAmount)
                {
                    PlayerPrefs.SetInt("Stage" + nextStage.ToString(), 1);
                    popUp_clear.SetActive(true);
                }
                else
                {
                    popUp_Notice.SetActive(true);
                }
            }
        }
    }

    void LoadNextStage()
    {
        if (nextStage <= stageAmount)
        {
            PlayerPrefs.SetInt("Stage" + nextStage.ToString(), 1);
            SceneManager.LoadScene(string.Format("GameScene {0}", nextStage));
        }

    }

 
    public void btn_Next()
    {
        if (nextStage <= stageAmount)
        {
            SceneManager.LoadScene(string.Format("GameScene {0}", nextStage));
        }
        else
        {
            popUp_Notice.SetActive(true);
        }
    }

    public void btn_Back()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void btn_Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
