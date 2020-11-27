using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
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
        SoundManager.instance.play_menu_close();
    }

    public void open_Menu()
    {
        btn_Menu.SetActive(false);
        popUp_Menu.SetActive(true);
        Time.timeScale = 0;
        SoundManager.instance.play_menu_open();
    }
    public void btn_Next()
    {
        if (StageManager.instance.nextStage <= StageManager.instance.stageAmount)
        {
            SceneManager.LoadScene(string.Format("GameScene {0}", StageManager.instance.nextStage));
        }
        else
        {
            popUp_Notice.SetActive(true);
        }
    }
}
