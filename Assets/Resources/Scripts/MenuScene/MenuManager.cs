﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [System.Serializable]
    public class Stages
    {

        public string StageText;
        public int Unlock;
        public bool isInteractible;
        public Button.ButtonClickedEvent OnClick;
    }
    public GameObject StageButton;
    public Transform Spacer;
    public List<Stages> StageList;

    // Use this for initialization
    void Start()
    {
        instance = this;
        //DeleteData(); //게임 세이브 데이터 삭제
        FillList();
    }
    void FillList()
    {
        foreach (var stage in StageList)
        {
            GameObject newbutton = Instantiate(StageButton) as GameObject;
            StagebtnManager button = newbutton.GetComponent<StagebtnManager>();

            button.StageText.text = stage.StageText;

            if (PlayerPrefs.GetInt("Stage" + button.StageText.text) == 1)
            {
                stage.Unlock = 1;
                stage.isInteractible = true;
            }
            //세이브 데이터가 있으면 스테이지 언락

            button.unlocked = stage.Unlock;
            button.GetComponent<Button>().interactable = stage.isInteractible;
            button.GetComponent<Button>().onClick.AddListener(() => startStage("GameScene " + button.StageText.text));
            //해당 스테이지 호출

            newbutton.transform.SetParent(Spacer);
        }
        //SAVE();
    }

    public void BackHome() {
    	SceneManager.LoadScene("LogoScene");
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void startStage(string value) {
        SceneManager.LoadScene(value);
    }
}
