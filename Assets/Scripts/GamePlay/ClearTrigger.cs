using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    public StageController stageController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterController character = collision.GetComponent<CharacterController>();
        if (character != null)
        {
            stageController.StageClear();
        }
    }
   
}
