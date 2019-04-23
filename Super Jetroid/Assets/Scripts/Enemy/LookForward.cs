using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour
{

    public Transform sightStart, sightEnd;
    public bool needsCollision = true;
    private bool collision = false;

    void Update()
    {
        //Creates a line of sight and triggers the bool if something enters it
        collision = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Solid"));

        //Visual for the line of sight
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if(collision == needsCollision)
        { this.transform.localScale = new Vector3((transform.localScale.x == 1) ? -1 : 1, 1, 1); }
    }
}
