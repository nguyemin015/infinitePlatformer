using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCountStore;
    private float speedMilestoneCount;

    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask WhatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager Manager;

        // Start is called before the first frame update
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();        

            myCollider = GetComponent<Collider2D>();

            myAnimator = GetComponent<Animator>();

            speedMilestoneCount = speedIncreaseMilestone;

            moveSpeedStore = moveSpeed;
            speedMilestoneCountStore = speedMilestoneCount;
            speedIncreaseMilestoneStore = speedIncreaseMilestone;
        }

        // Update is called once per frame
        void Update()
        {
            grounded = Physics2D.IsTouchingLayers(myCollider, WhatIsGround);

            if(transform.position.x > speedMilestoneCount) //speed up 
            {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
//If grounded, can jump. If not gounded, can't jump.   
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if(grounded)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                }
            }
//Animation for moving and jumping
            myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
            myAnimator.SetBool("Grounded", grounded); 
        }
    
        void OnCollisionEnter2D (Collision2D other)
        {
            if(other.gameObject.tag == "killbox")
            {
                Manager.RestartGame();
                moveSpeed = moveSpeedStore;
                speedMilestoneCount = speedMilestoneCountStore;
                speedIncreaseMilestone = speedIncreaseMilestoneStore;
            }
        }
}
