using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject popUp_clear, popUp_Notice;
    MenuManager menuMng;
    int stageAmount, currentStage, nextStage;
    public bool isClear = false;

    // Start is called before the first frame update
    private void Start()
    {
        menuMng = MenuManager.instance;
        stageAmount = menuMng.StageList.Count ;
        GameClear();
    }

    void GameClear()
    {
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


}
