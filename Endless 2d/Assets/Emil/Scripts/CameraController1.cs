using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    public PlayerController1 thePlayer;

    private Vector3 lastPlayerPosition;//viimeinen Playerin sijainti
    private float distanceToMove;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController1>();//etsii PlayerController1:en
        lastPlayerPosition = thePlayer.transform.position;
    }

   
    void Update()
    {
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;//paljonko tarvii likkua

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);//kameran sijainti samassa kuin player
        lastPlayerPosition = thePlayer.transform.position;//viimeisin sijainti muuttuu nykyiseksi sijainniksi
    }
}
