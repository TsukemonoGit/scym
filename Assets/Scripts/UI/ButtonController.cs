using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Core;
public class ButtonController : MonoBehaviour
{
    public float stepSize = 0.1f;
    GameModel model = Schedule.GetModel<GameModel>();
    public DestructibleBox dBox;
    public ObstacleBox oBox;
    bool LeftButtonDown;
    bool RightButtonDown;
    bool LeftButtonUp;
    bool RightButtonUp;
    bool UpButtonDown;
    bool DownButtonDown;

    private void Update()
    {
        if (model.stageController.isGameOver == true) { return; }
        CharacterControl();
    }
    void CharacterControl()
    {

        if (LeftButtonDown)
        {
            model.player.nextMoveCommand = -stepSize;
            model.player.stop_bool = false;
        }
        else if (RightButtonDown)
        {
            model.player.nextMoveCommand = stepSize;
            model.player.stop_bool = false;
        }

        else if (LeftButtonUp)
        {
            model.player.stop_bool = true;
            model.player.tomarubasyo = (int)Mathf.Floor(model.player.transform.position.x);
            model.player.nextMoveCommand = 0;
        }
        else if (RightButtonUp)
        {
            model.player.stop_bool = true;
            model.player.tomarubasyo = (int)Mathf.Ceil(model.player.transform.position.x);
            model.player.nextMoveCommand = 0;
        }
        else if (UpButtonDown)
        { //ボム爆破model.player.nextMoveCommand = Vector3.up * stepSize;
            model.player.ExplodeBomb();
            dBox.Bombed();
            oBox.Bombed();
        }

        else if (DownButtonDown)
        { //ボム設置
            model.player.SetBomb();
        }

    }
    public void DownRight()
    {
        AllFalse();
        RightButtonDown = true;
    }
    public void DownLeft()
    {
        AllFalse();
        LeftButtonDown = true;
    }
    public void DownUp()
    {
        AllFalse();
        UpButtonDown = true;
    }
    public void DownDown()
    {
        AllFalse();
        DownButtonDown = true;
    }
    public void LeftUp()
    {
        AllFalse();
        LeftButtonUp = true;
    }
    public void RightUp()
    {
        AllFalse();
        RightButtonUp = true;
    }

    void AllFalse()
    {
        LeftButtonDown=false;
        RightButtonDown=false;
        LeftButtonUp=false;
        RightButtonUp=false;
        UpButtonDown=false;
        DownButtonDown=false;
    }
}

