using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public int stageNum = 1;
    public GameObject gameOverCanvas;
    public GameObject botanCanva;
    private void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
        botanCanva.SetActive(false);
    }
    public void OnClickBack()
    {
        SceneManager.LoadScene(stageNum);
    }
    public void OnClickClose()
    {
        SceneManager.LoadScene(0);
    }
    bool botan = false;
    public void OnClickButton()
    {
        if (botan == false)
        {
            botanCanva.SetActive(true);
            botan = true;
        }
        else
        {
            botanCanva.SetActive(false);
            botan = false;
        }
    }
    public bool isGameOver=false;
    public void GameOver()
    {
        //Time.timeScale = 0;
        isGameOver = true;
        gameOverCanvas.SetActive(true);
    }
    public void StageClear()
    {

        Debug.Log("Clear");
        if (stageNum > GameManage.control.LoadPref())
        {
            GameManage.control.SavePref(stageNum);
        }

        ClearParticle();
    }
    public GameObject particle_pre;
    public Transform clearPos;
    void ClearParticle()
    {
        GameObject particle = Instantiate(particle_pre, clearPos.position, Quaternion.identity);
        //var main = particle.GetComponent<ParticleSystem>().main;
        //main.stopAction = ParticleSystemStopAction.Callback;

    }
 
}