using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController3 : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;

        if (curPos.x < -15)
        {
            transform.position = new Vector3(11, curPos.y, curPos.z);
        }
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
