using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    protected int stageAmount, currentStage, nextStage;
    [HideInInspector] public bool isClear;
    private GameObject player;

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
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (isClear == true)
        {
            player.gameObject.GetComponent<Animator>().SetBool("isClear", true);
            Invoke("GameClear",1);
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
