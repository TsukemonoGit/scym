using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    SpriteRenderer ren;
    BoxCollider2D boxCol;
    public Sprite sprite_befor;
    public Sprite sprite_after;
    bool isBombed =false;

    public ObstacleBox oBox;
    private void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        
            oBox.AddList(this.gameObject);

        gameObject.layer = default;
    }

    public void Bombed()
    {
        Debug.Log("tes");
        if (isBombed)
        {
            ren.sprite = sprite_after;
            boxCol.isTrigger = false;
            gameObject.layer = 6;//"Ground"床判定に含める
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  Debug.Log(collision);
        BombController controller = collision.gameObject.GetComponent<BombController>();
        if (controller != null)
        {
            Debug.Log("tes");
            isBombed = true;
            oBox.AddOnList(this.gameObject);
        }

    }
   



    void Start()
    {
        ren.sprite = sprite_befor;
        boxCol.isTrigger = true;
    }
    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(10, 100, 50, 50), "bomb"))
    //    {
    //        Bombed();

    //    }
    //    if (GUI.Button(new Rect(10, 150, 100, 50), "bombReset"))
    //    {
    //        ren.sprite = sprite_befor;
    //        boxCol.isTrigger = true;

    //    }
    //}
}
