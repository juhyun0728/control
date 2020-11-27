using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string MenuScene;
    void Start()
    {
        
    }
   	public void StartGame() {
        SoundManager.instance.play_gameStart();
        Invoke("loadMenu", 0.2f);      
    }
    
    void loadMenu()
    {
    SceneManager.LoadScene(MenuScene);
    }
    public void ExitGame() {
		#if UNITY_EDITOR
        	UnityEditor.EditorApplication.isPlaying = false;
		#else
        	Application.Quit() // 어플리케이션 종료
		#endif
    }
}
