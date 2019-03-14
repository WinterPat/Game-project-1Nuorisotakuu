using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
	
	[SerializeField] float walkingSpeed;
    [SerializeField] float flyingSpeed;
    [SerializeField] float jumpStrength;
    [SerializeField] float maxSpeed;
    [SerializeField] Vector3 legalSpace;
    [SerializeField] Collider2D playerCollider;
    

    private Rigidbody2D player;
    private float speed;
	private bool jump = false;
	private bool canJump = false;

    private Bounds virtualBox;

    void Start()
    {
        virtualBox = new Bounds(new Vector3(0, 0, 0), legalSpace);
		player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && canJump) {
			jump = true;
		}
        
        // if the player goes out of the game area we return him and reset his velocity
        if (!playerCollider.bounds.Intersects(virtualBox))
        {
            transform.position = new Vector2(-8, 0);
            player.velocity = Vector2.zero;
        }
    }

	void FixedUpdate()
	{
        if (Math.Abs(player.velocity.x) < maxSpeed)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(moveHorizontal, 0.0f);
            player.AddForce(movement * speed);
        }

		if (jump && canJump) {
			Vector2 jumpVector = new Vector2(0.0f, jumpStrength);
			player.AddForce(jumpVector, ForceMode2D.Impulse);
			jump = false;
		}


	}

	void OnCollisionEnter2D(Collision2D other)
	{
		canJump = true;
        speed = walkingSpeed;
	}

	void OnCollisionExit2D(Collision2D other)
	{
		canJump = false;
        speed = flyingSpeed;
	}
    
	void OnTriggerStay2D(Collider2D other) 
	{
        // if the player collides with a platform,
        // we want to add it as a parent so that the player moves with it
        // check for parent == null so we wont keep adding gameobjects
		if (other.gameObject.CompareTag("platform") && transform.parent == null) {
            // we have to add an empty gameobject between the platform and the player to avoid inheriting parent's scale
            GameObject empty = new GameObject();
            empty.transform.parent = other.transform;
			transform.parent = empty.transform;
		}
	}

	void OnTriggerExit2D(Collider2D other)
    { 
        // when the player is no longer in contact with the platform, we remove the player's parent
		if (other.gameObject.CompareTag("platform") && transform.parent != null) {
            // we need a reference to the middleparent so we can destroy that later
            GameObject obj = transform.parent.gameObject;
			transform.parent = null;
            Destroy(obj);
		}
	}
}
