using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerF : MonoBehaviour
{
    public float speed;
    //public GameObject player;

    //private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed += Time.deltaTime / 10;

        transform.Translate(Vector2.right * Time.deltaTime * speed);


        //transform.position = player.transform.position + offset;
    }
}
