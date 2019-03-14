using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class PlayerController3 : MonoBehaviour
{
    public float speed;
    public float PowerUpTimer = 0.0f;
    public float Timer = 0.0f;
    public Text countText;
    public Text winText;

    [SerializeField] float jumpStrength;

    //private Rigidbody player;
    private Rigidbody2D player;

    private bool jump = false;
    private bool canJump = false;
    private int count;
    private bool facingRight;


    void Start()
    {
        //player = GetComponent<Rigidbody>();
        player = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        PowerUp();
        winText.text = "";
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = transform.position;
        Vector2 pos = transform.position;

        //pos.z = 0;
        transform.position = pos;

        //transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        transform.eulerAngles = new Vector2(0.0f, 0.0f);


        if (Input.GetKeyDown("space") && canJump)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        player.AddForce(movement * speed);
        Timer += Time.deltaTime;
        speed += Time.deltaTime / 20;

        //Players flip animation
        if (moveHorizontal > 0f)
        {
            transform.localScale = new Vector2(0.3f, 0.3f);
        }
        else if(moveHorizontal < 0f)
        {
            transform.localScale = new Vector2(-0.3f, 0.3f);
        }

        if (jump && canJump)
        {
           // Vector3 jumpVector = new Vector3(0.0f, jumpStrength, 0.0f);
            Vector2 jumpVector = new Vector2(0.0f, jumpStrength);

            player.AddForce(jumpVector);
            jump = false;
        }
        if (PowerUpTimer < Timer)
        {
            speed = Timer / 20 + 5;
        }
        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        canJump = true;
        Debug.Log("collision");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            PowerUp();
            SetCountText();
            count = count + 1;

        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        canJump = false;
        Debug.Log("out of collision");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("ontriggerstay in playercontroller");
        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("ontriggerexit in playercontroller");
        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent = null;
        }
    }

    //Piste laskuri
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        count = count + 1;
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
    //PowerUps
    void PowerUp()
    {
        speed = speed * 2;
        PowerUpTimer = Timer + 5;
    }
    
}