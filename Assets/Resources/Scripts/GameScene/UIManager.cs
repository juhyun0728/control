using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : StageManager
{
    public static new UIManager instance;
    public GameObject popUp_clear, popUp_Notice, popUp_Menu, btn_Menu;

    private void Start()
    {
        instance = this;
    }

    public void btn_Home()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void btn_Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void btn_back()
    {
        popUp_Menu.SetActive(false);
        btn_Menu.SetActive(true);
        Time.timeScale = 1;
    }

    public void open_Menu()
    {
        btn_Menu.SetActive(false);
        popUp_Menu.SetActive(true);
        Time.timeScale = 0;
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
}
