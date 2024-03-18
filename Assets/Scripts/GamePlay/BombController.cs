using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    //public GameObject[] destroyObj;
    public void MyDestroy()
    {
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        CharacterController controller = collision.gameObject.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.isGameOver = true;
           // Debug.Log(controller);
            //destroyObj = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log(collision);
        CharacterController controller = collision.gameObject.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.isGameOver = false;
           // Debug.Log(controller);
            //destroyObj = collision.gameObject;
        }

    }
}
