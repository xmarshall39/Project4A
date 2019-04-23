using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Animator animator;
    private bool down;

    public DoorTrigger[] doorTriggers;
    public bool sticky;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetInteger("AnimState", 1);

        down = true;

        foreach (DoorTrigger trigger in doorTriggers)
        {
            if(trigger != null) { trigger.Toggle(true); }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Prevents the switch from returning to neutral if sticky is designated
        if(sticky && down) { return; }


        animator.SetInteger("AnimState", 2);

        down = false;

        foreach (DoorTrigger trigger in doorTriggers)
        {
            if (trigger != null) { trigger.Toggle(false); }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = sticky ? Color.red : Color.green;
        foreach (DoorTrigger trigger in doorTriggers)
        {
            if (trigger != null)
            { Gizmos.DrawLine(transform.position, trigger.door.transform.position); }
        }
    }
}
