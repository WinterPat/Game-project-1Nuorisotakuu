using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorF : MonoBehaviour
{

    public GameObject thePlatform;//tämä generoidaan 
    public Transform generationPoint;//paikka missä pitää tietää tarviiko luoda lisää platformeja
    public float distanceBetween;//platformien etäisyys toisistaan

    private float platformWidth;//leveys


    public float distanceBetweenMin;
    public float distancebetweenMax;

    //public GameObject[] thePlatforms;//joukko
    private int platformSelector;//valitsee mikä pitää luoda
    private float[] platformWidths;//platfomien leveys


    public ObjectPooler1[] theObjectPools;

    private float minHeight;//min raja korkeuksille
    public Transform maxHeightPoint;
    private float maxHeight;//max raja
    public float maxHeightChange;
    private float heightChange;//paljonko tarvii siirtyä

    private PickUpGenerator thePickUpGenerator;

    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        thePickUpGenerator = FindObjectOfType<PickUpGenerator>();
    }

    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            Debug.Log(theObjectPools.Length);
            distanceBetween = Random.Range(distanceBetweenMin, distancebetweenMax);
            platformSelector = Random.Range(0, theObjectPools.Length);//arrayn pituus
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;

            }
            else if (heightChange < minHeight)

            {
                heightChange = minHeight;
            }
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);//siirtää platformia


            //Instantiate(/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);//kopsaa platformit
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);


        }
    }
}

