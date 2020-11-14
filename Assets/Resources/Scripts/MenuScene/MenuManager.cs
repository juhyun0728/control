using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public void BackHome() {
    	SceneManager.LoadScene("LogoScene");
    }

    public void startStage() {
    	switch (EventSystem.current.currentSelectedGameObject.name) {
    		case "Stage1Button" :
    			SceneManager.LoadScene("GameScene 1");
    			break;
    		case "Stage2Button" :
    			SceneManager.LoadScene("GameScene 2");
    			break;
    		case "Stage3Button" :
    			SceneManager.LoadScene("GameScene 3");
    			break;
    		case "Stage4Button" :
    			SceneManager.LoadScene("GameScene 4");
    			break;
    		case "Stage5Button" :
    			SceneManager.LoadScene("GameScene 5");
    			break;
    		case "Stage6Button" :
    			SceneManager.LoadScene("GameScene 6");
    			break;
    		default :
    			break;
    	}
    }
}
