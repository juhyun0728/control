using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OBtnMng : MonoBehaviour
{
    public OObjectMng ObjectMng;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateMenuPopup()
    {
        ObjectMng.MenuPopup.SetActive(true);
    }

    public void CloseMenuPopup()
    {
        ObjectMng.MenuPopup.SetActive(false);
    }

    public void HomeBtnClick()
    {
        SceneManager.LoadScene("Scenes/MenuScene");
    }

}
