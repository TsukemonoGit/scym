using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Core;
public class InputController : MonoBehaviour
{
    public float stepSize = 0.1f;
    GameModel model = Schedule.GetModel<GameModel>();
    public DestructibleBox dBox;
    public ObstacleBox oBox;
    private void Update()
    {
        if (model.stageController.isGameOver == true) { return; }
        CharacterControl();
    }
    void CharacterControl()
    {
     
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            model.player.nextMoveCommand = -stepSize;
            model.player.stop_bool = false;
            //model.player.state = CharacterController.State.move;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            model.player.nextMoveCommand = stepSize;
            model.player.stop_bool = false;
            // model.player.state = CharacterController.State.move;
        }


        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            model.player.stop_bool = true;
            model.player.tomarubasyo = (int)Mathf.Floor(model.player.transform.position.x);
            model.player.nextMoveCommand = 0;
            //model.player.state = CharacterController.State.stopping;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            model.player.stop_bool = true;
            model.player.tomarubasyo = (int)Mathf.Ceil(model.player.transform.position.x);
            model.player.nextMoveCommand = 0;
            //model.player.state = CharacterController.State.stopping;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        { //ボム爆破model.player.nextMoveCommand = Vector3.up * stepSize;
            model.player.ExplodeBomb();
            dBox.Bombed();
            oBox.Bombed();
        }


        else if (Input.GetKeyDown(KeyCode.DownArrow))
        { //ボム設置
            model.player.SetBomb();
        }

    }
 
    
}