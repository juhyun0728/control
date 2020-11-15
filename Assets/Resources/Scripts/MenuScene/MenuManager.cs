using System.Collections;
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
        //DeleteData();
        FillList();
    }
    void FillList()
    {
        foreach (var stage in StageList)
        {
            Debug.Log(stage);
            GameObject newbutton = Instantiate(StageButton) as GameObject;
            StagebtnManager button = newbutton.GetComponent<StagebtnManager>();

            button.StageText.text = stage.StageText;

            if (PlayerPrefs.GetInt("Stage" + button.StageText.text) == 1)
            {
                stage.Unlock = 1;
                stage.isInteractible = true;
            }

            button.unlocked = stage.Unlock;
            button.GetComponent<Button>().interactable = stage.isInteractible;
            button.GetComponent<Button>().onClick.AddListener(() => startStage("GameScene " + button.StageText.text));

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
