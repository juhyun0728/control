using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject popUp_clear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameClear()
    {
        popUp_clear.SetActive(true);
    }

    public void btn_Retry()
    {

    }

    public void btn_Back()
    {
        SceneManager.LoadScene("MenuScene");
    }


}
