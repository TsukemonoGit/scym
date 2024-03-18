using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBox : MonoBehaviour
{
  public List <GameObject> list=new List<GameObject>();
    public List<GameObject> destroyList = new List<GameObject>();
    public void AddList(GameObject obj)
    {
        list.Add(obj);
    }
    public void RemoveList(GameObject obj)
    {
        list.Remove(obj);
    }
    public void AddDestroyList(GameObject obj)
    {
        destroyList.Add(obj);
    }
    public void RemoveDestroyList(GameObject obj)
    {
        destroyList.Remove(obj);
    }
    public void Bombed()
    {
        for (int i = 0; i < destroyList.Count; i++)
        {
            //    Destroy(destroyList[i].gameObject);
            destroyList[i].gameObject.GetComponent<DestructibleController>().Bombed();
           // RemoveList(destroyList[i].gameObject);
        }
     //   destroyList = new List<GameObject>();
    }
}
