using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MyButton : MonoBehaviour
{
    public int myStageNum;
    private  Button myButton;
    private Color myColor;
    private Image img;
    private TMP_Text myText;
    public void Awake()
    {
        img = GetComponent<Image>();
      
        myText = GetComponentInChildren<TMP_Text>();
       
        myButton = GetComponent<Button>();

        myColor = img.color;
        myText.enabled = false;
        myButton.interactable = false;
        img.color = Color.gray;
    }
    public void Start()
    {
      
    }
    // Start is called before the first frame update
    public void OnClickButton()
    {
        SceneManager.LoadScene(myStageNum);
    }
    public void SetInteractable()
    {
        myButton.interactable=true;
        img.color = myColor;
        myText.enabled = true ;
    }
}
