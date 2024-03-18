using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Core;
public class GameController : MonoBehaviour
{
    //このモデルはパブリックでインスペクターから変更できる。
    // 参照は必要に応じて共有され、Unityは新しいインスタンスを作成するのではなく、
    //共有参照を逆シリアル化します。
    //この動作を維持するにはこのスクリプトを最後に逆シリアル化する必要があります。
    //そのためのスケジュール？？
    public GameModel model;

    protected virtual void OnEnable()
    {
        Schedule.SetModel<GameModel>(model);
    }

    protected virtual void Update()
    {
        Schedule.Tick();
    }
}
