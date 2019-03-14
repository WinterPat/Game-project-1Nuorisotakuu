using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGenerator : MonoBehaviour
{

    public ObjectPooler1 pickupPool;
    public float distanceBetweenPickups;

    public void SpawnPickUps(Vector3 startPosition)
    {
        GameObject pickup1 = pickupPool.GetPooledObject();
        pickup1.transform.position = startPosition;
        pickup1.SetActive(true);

        GameObject pickup2 = pickupPool.GetPooledObject();
        pickup2.transform.position = new Vector3(startPosition.x - distanceBetweenPickups, startPosition.y, startPosition.z);
        pickup2.SetActive(true);

        GameObject pickup3 = pickupPool.GetPooledObject();
        pickup3.transform.position = new Vector3(startPosition.x - distanceBetweenPickups, startPosition.y, startPosition.z);
        pickup3.SetActive(true);
    }
}
