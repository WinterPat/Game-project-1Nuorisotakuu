using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Classes;
using Assets.Database;

public class GameController : MonoBehaviour
{
    private System.Random rnd;
    private List<GameObject> platforms;
    [SerializeField] GameObject platformPrefab = null;
    [SerializeField] int maxPlatforms = 0;
    private DatabaseConnection dbConn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void ManagePlatforms()
    {
        if (this.platforms.Count < maxPlatforms)
        {
            float yPos = ((float) rnd.Next(-40, 40)) / 10;
            float xPos = ((float) rnd.Next(110, 200)) / 10;
            GameObject go = Instantiate(platformPrefab);
            go.transform.position = new Vector3(xPos, yPos, 0);
            this.platforms.Add(go);
        }

        List<GameObject> rest = new List<GameObject>();

        foreach (GameObject go in this.platforms)
        {
            if (go.transform.position.x < -10)
            {
                Destroy(go);
            } else
            {
                rest.Add(go);
            }
        }

        this.platforms = rest;
    }
}
