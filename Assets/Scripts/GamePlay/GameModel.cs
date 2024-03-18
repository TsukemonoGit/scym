using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameModel 
{
    /// <summary>
    /// このクラスはControlに必要なデータとゲームプレイを変更するのに必要なデータすべてのデータを提供する。
    /// </summary>

    public InputController input;
    public CharacterController player;
    public StageController stageController;
 //   public DestructibleController box01;
    

}
