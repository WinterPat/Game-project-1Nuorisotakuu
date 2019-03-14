using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class PlayerControllerF : MonoBehaviour
{
    public float speed;
    public float PowerUpTimer;
    public float Timer = 0.0f;
    public Text countText;

    public GameManager1 theGameManager;

    public float jumpStrength;
    public float doubleJumpStrength;

    public float pickUpBoost;

    //private Rigidbody player;
    private Rigidbody2D player;

    private bool jump = false;
    private bool canJump = false;

    private bool doubleJump = false;
    private bool canDoubleJump = false;

    private Animator myAnimator;

    private bool facingRight;
    private float moveSpeedStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    public ScoreManager1 theScoreManager;

    private bool grounded;




    void Start()
    {
        //player = GetComponent<Rigidbody>();
        player = GetComponent<Rigidbody2D>();
        
        PowerUpTimer = 0;
        facingRight = true;
        theGameManager = FindObjectOfType<GameManager1>();

        myAnimator = GetComponent<Animator>();
}

// Update is called once per frame
void Update()
    {
        Vector2 pos = transform.position;

        transform.position = pos;
   
        transform.eulerAngles = new Vector2(0.0f, 0.0f);

        if (Input.GetKeyDown("space") && canJump)
        {
            jump = true;
        }
        if (Input.GetKeyDown("space") && canDoubleJump)
        {
            doubleJump = true;
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
            transform.localScale = new Vector2(0.8663616f, 0.7232149f);
        }
        else if (moveHorizontal < 0f)
        {
            transform.localScale = new Vector2(-0.8663616f, 0.7232149f);
        }

        if (jump && canJump)
        {
            // Vector3 jumpVector = new Vector3(0.0f, jumpStrength, 0.0f);
            Vector2 jumpVector = new Vector2(0.0f, jumpStrength);

            player.AddForce(jumpVector);
            jump = false;
        }
        if (doubleJump && canDoubleJump)
        {
            // Vector3 jumpVector = new Vector3(0.0f, jumpStrength, 0.0f);
            Vector2 jumpVector = new Vector2(0.0f, doubleJumpStrength);

            player.AddForce(jumpVector);
            doubleJump = false;
            canDoubleJump = false;
        }

        if (PowerUpTimer < Timer) 
        {
            speed = Timer / 20 + 10;
        }
        myAnimator.SetFloat("Speed", movement.x);
        myAnimator.SetBool("canJump", canJump);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {

            theGameManager.RestartGame();
            speed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
        grounded = true;
        canJump = true;
        canDoubleJump = false;
        Debug.Log("collision");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
           
            speed = speed + pickUpBoost;
            PowerUpTimer = Timer + 5;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        canJump = false;
        canDoubleJump = true;
        Debug.Log("out of collision");
        grounded = false;
        
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
}
