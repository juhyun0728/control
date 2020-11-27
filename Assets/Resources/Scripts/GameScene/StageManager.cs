using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    [HideInInspector] public int stageAmount, currentStage, nextStage;
    public bool isClear;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        stageAmount = 5 ;
        Time.timeScale = 1;
        isClear = false;

    }

    private void Update()
    {
        if (isClear == true)
        {
            Invoke("GameClear",1);
        }
    }

    void GameClear()
    {
        Time.timeScale = 0;
        SoundManager.instance.play_clear();
        for (int i = 1; i <= stageAmount; i++)
        {
            if (SceneManager.GetActiveScene().name == "GameScene " + i)
            {
                currentStage = i;
                nextStage = currentStage + 1;
                
                if (nextStage <= stageAmount)
                {
                    PlayerPrefs.SetInt("Stage" + nextStage.ToString(), 1);
                    UIManager.instance.popUp_clear.SetActive(true);
                }
                else
                {
                    UIManager.instance.popUp_Notice.SetActive(true);
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
}
