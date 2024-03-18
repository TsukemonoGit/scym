using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage control;
    //シングルトン
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
    public void SavePref(int num)
    {
        PlayerPrefs.SetInt("Data", num);
    }
    public int  LoadPref()
    {

        int num =PlayerPrefs.GetInt("Data");
        
        return num;
    }
}
