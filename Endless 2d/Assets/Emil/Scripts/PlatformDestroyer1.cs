using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer1 : MonoBehaviour
{

    public GameObject platformDestructionPoint;

    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");//"täyttää" objectin tuhopisteellä


    }

  
    void Update()
    {
        
        if(transform.position.x < platformDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
