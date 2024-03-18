using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シンプルな追従カメラクラス。
/// スタートしたときのフォーカス座標、フォーカスを追跡するときにそのオフセットを保持します。
/// </summary>

public class CameraController : MonoBehaviour
{
    public Transform focus;
    public float smoothTime = 2;

    //  Vector3 offset;
    float offsetY;
    public Transform clearPos;
    private void Awake()
    {
        //offset = focus.position - transform.position;
        offsetY = focus.position.y - transform.position.y;
      
    }
   
void Update()
    {
        if (transform.position.y < clearPos.position.y) { return; }
        // transform.position = Vector3.Lerp(transform.position , focus.position - offset, Time.deltaTime * smoothTime);        
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, focus.position.y - offsetY, transform.position.z), Time.deltaTime * smoothTime);

    }
}
