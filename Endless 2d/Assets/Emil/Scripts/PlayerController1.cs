using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    public float moveSpeed;//nopeutta varten
    private float moveSpeedStore;
    public float speedMultiplier;//nopeuden kertoja
    public float speedIncreaseMilestone;//tietyssä kohtaa nopeutuu
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
    public float jumpForce;//hypyn voimaa varten

    public float jumpTime;//kuinka kauan pelaaja voi jatkaa hyppäämistä
    private float jumpTimeCounter;

    private Rigidbody2D myRigidbody;


    public bool grounded; //onko maassa vai ei
    public LayerMask WhatIsGround;//mikä on maata
    public Transform groundCheck;
    public float groundCheckRadius;
    //private Collider2D myCollider;//2d collider

    public GameManager1 theGameManager;
    private Animator myAnimator;//controlloidaan animaattoria

    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();//etsii Playeristä rigidbody2d:tä
        //myCollider = GetComponent<Collider2D>();//etsii Playeristä Colliderin2d:n
        myAnimator = GetComponent<Animator>();//etsii Playeristä Animatorin
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    
    void Update()     
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, WhatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);

        if(transform.position.x > speedMilestoneCount)//kasvatta nopeutta tietyissä kohtaa
        {
            speedMilestoneCount = speedIncreaseMilestone;

            speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;//milestone kasvu
            moveSpeed = moveSpeed * speedMultiplier;
        }
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);//x on moveSpeed ja y pysyy samana

        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))//toimii painamalla spacea tai hiiren left clickkiä
        {
            if (grounded)//jos maassa 
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);//x ei muutu ja y muuttuu JumpForcen mukaan
            }
        }
        if(Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))//ei voi hypätä liikaa 
        {
            jumpTimeCounter = 0;
        }

        if(grounded)
        {
            jumpTimeCounter = jumpTime;//resetoi
        }



        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);//Laittaa floatin arvon.
        myAnimator.SetBool("Grounded", grounded);//Muutetaan Groundedia groundedin mukaan
    }

    void OnCollisionEnter2D (Collision2D other)//kun boxcolliderit kohtaa
    {
        if(other.gameObject.tag == "killbox")
        {
            
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
        Debug.Log("collision");
    }
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Out of collision");
    }
    

}
