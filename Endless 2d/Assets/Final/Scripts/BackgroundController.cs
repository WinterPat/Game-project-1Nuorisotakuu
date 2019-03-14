using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public List<GameObject> things;

    [SerializeField] Transform cameraTransform;
    [SerializeField] float speed1 = 0.4f;
    [SerializeField] float speed2 = 0.2f;
    private Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random();
        foreach (GameObject gobj in things)
        {
            gobj.GetComponent<Rigidbody2D>().velocity = new Vector2((r.Next(2, 5) / 10.0f), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 curCamPos = cameraTransform.position;
        foreach (GameObject gobj in things)
        {
            if (gobj.transform.position.x < curCamPos.x - 20)
            {
                gobj.transform.position = new Vector2(gobj.transform.position.x + 40, gobj.transform.position.y);
            }
        }
    }

    private void FixedUpdate()
    {

    }
}
