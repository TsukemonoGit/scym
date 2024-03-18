using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StageClick : MonoBehaviour
{
    public GameObject[] stageButton;
    [SerializeField]private int unlockNum;
    public void OnClickClose()
    {
        Application.Quit();
    }
    public void Start()
    {
        SetButton();

    }
    void OnSceneLoaded(Scene loaded)
    { 
        SetButton(); 
    }

        void SetButton()
    {

        unlockNum = GameManage.control.LoadPref();
        if (unlockNum > 3) { unlockNum = 3; }
        for (int i = 0; i <= unlockNum; i++)
        {
            stageButton[i].GetComponent<MyButton>().SetInteractable();
           
        }
        
    }
}
