using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used to follow the player for stricly horizontal levels

public class FollowPlayerX : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    
    void Start()
    {
        
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = new Vector3(transform.position.x - player.transform.position.x, 0f, -10f);
    }

    
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if(player)
            transform.position = new Vector3(player.transform.position.x, 0f, 0f) + offset;
    }
}

