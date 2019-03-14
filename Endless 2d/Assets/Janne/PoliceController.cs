using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    [SerializeField] float speed = 0.05f;
    [SerializeField] float wait = 2f;

    private Vector3 target;
    private Transform playerLocation;
    private float prevTime;
    
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.Find("Player").GetComponent<Transform>();
        target = playerLocation.position;

    }

    private void setNewLocation()
    {
        target = playerLocation.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == target)
        {
            Invoke("setNewLocation", wait);
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
}
