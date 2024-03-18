using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBox : MonoBehaviour
{
   
        public List<GameObject> list = new List<GameObject>();
        public List<GameObject> onList = new List<GameObject>();
        public void AddList(GameObject obj)
        {
            list.Add(obj);
        }
        public void RemoveList(GameObject obj)
        {
            list.Remove(obj);
        }
        public void AddOnList(GameObject obj)
        {
            onList.Add(obj);
        }
     
        public void Bombed()
        {
            for (int i = 0; i < onList.Count; i++)
            {
                onList[i].GetComponent<ObstacleController>().Bombed();
                RemoveList(onList[i].gameObject);
            }
            onList = new List<GameObject>();
        }
    
}
