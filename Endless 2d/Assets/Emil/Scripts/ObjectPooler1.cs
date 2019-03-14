using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPooler1 : MonoBehaviour
{
    public GameObject pooledObject; //mitä objektia poolataan
    public int pooledAmount;//objektien määrä, joita poolataan


    List<GameObject> pooledObjects;


    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);//pistetään listaan deactivoitu objekti
        }


    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {

            if (!pooledObjects[i].activeInHierarchy)
            {
               
                    return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add (obj);
        return obj;
    }
}
       
   
