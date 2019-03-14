using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
	[SerializeField] float speed = 0;


    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trying to destroy platform");
        if (collision.gameObject.CompareTag("platform_guard"))
        {
            
            Destroy(collision.gameObject.transform.parent);
        }
    }
}
