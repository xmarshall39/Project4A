using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienB : MonoBehaviour
{
    private bool readyToAttack = false;
    private Animator animator;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    //Begin animating the alien
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Found you!");
 
             animator.SetInteger("AnimState", 1); 
        }
 
    }

    //See if player is still there during attack
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && animator.GetInteger("AnimState") >= 1)
        {
     
            if (readyToAttack)
            {
                print("May death become you.");
                var explode = collision.GetComponent<ExplodePlayer>() as ExplodePlayer;
                explode.OnExplode();
                
            }
        }
    }

    //Reset once the player leaves
    private void OnTriggerExit2D(Collider2D collision)
    {
        readyToAttack = false;
        animator.SetInteger("AnimState", 0);
    }

    void Attack()
    {
        print("Readying Attack");
        readyToAttack = true;
    }

    private void Update()
    {
        //If I failed to kill the player, set attack to false
        if (GameObject.Find("Player")) { readyToAttack = false; }
    }
}
