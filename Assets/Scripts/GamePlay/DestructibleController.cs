using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleController : MonoBehaviour
{
    public Sprite[] sprite_hp;
    SpriteRenderer ren;
    private bool isBombed=false;
    public int hp;
    public void Bombed()
    {
     //   Debug.Log("tes");
        if (isBombed == true){
            
            hp--;
            dBox.RemoveDestroyList(this.gameObject);
            if (hp <= 0)
            {
                dBox.RemoveList(this.gameObject);
               
                Destroy(this.gameObject);
                return;
            }
            //hp=2のとき２
            ren.sprite = sprite_hp[ hp-1 ];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
  //      Debug.Log("ON");
        BombController controller = collision.gameObject.GetComponent<BombController>();
        if (controller != null)
        {
            isBombed = true;
            dBox.AddDestroyList(this.gameObject);
        }
       
    }
    public DestructibleBox dBox;
    private void Awake()
    {
       dBox.AddList(this.gameObject);
        ren = GetComponent<SpriteRenderer>();
    }
    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(10, 250, 100, 50), "boxBomb"))
    //    {
    //        Bombed();
    //    }
    //}
   
}