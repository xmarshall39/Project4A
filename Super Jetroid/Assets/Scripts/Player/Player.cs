using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jetSpeed = 15f;
    public float airSpeedMultiplier = .3f;
    public Vector2 maxVelocity = new Vector2(3, 5);
    public bool standing;

    private PlayerController controller;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float forceX = 0f;
        float forceY = 0f;
        
        var absVelX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
        var absVelY = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);

        if (absVelY < .2)
            standing = true;
        else
            standing = false;
        
        if (controller.moving.x != 0)
        {
            if (absVelX < maxVelocity.x) { 
                forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);
                transform.localScale = new Vector3(forceX > 0 ? 1 : -1, 1, 1);
            }
            animator.SetInteger("AnimState", 1);
        }
        else animator.SetInteger("AnimState", 0);

        if (controller.moving.y > 0)
        {
            if (absVelY < maxVelocity.y)
            {
                forceY = jetSpeed * controller.moving.y;
                
            }
            animator.SetInteger("AnimState", 2);
           
        }
        else if (absVelY > 0)
        {
            animator.SetInteger("AnimState", 3);
        }
        /*
        if (Input.GetKey("right"))
        {
            if (absVelX < maxVelocity.x)
                forceX = standing ? speed: speed * airSpeedMultiplier;
            transform.localScale = new Vector3(1, 1, 1);
        }

        

        //Speed is negative for left movement
        else if (Input.GetKey("left"))
        {
            if (absVelX < maxVelocity.x)
                forceX = forceX = standing ? -speed : -speed * airSpeedMultiplier; ;

            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey("up"))
        {
            if (absVelY < maxVelocity.y)
                forceY = jetSpeed;
        }
        */

        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
    }
}
