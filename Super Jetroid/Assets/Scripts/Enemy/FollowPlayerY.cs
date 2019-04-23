using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used to follow the player for stricly vertical levels
public class FollowPlayerY : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera


    void Start()
    {

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = new Vector3(0f, transform.position.y - player.transform.position.y, -10f);
    }


    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (player)
            transform.position = new Vector3(0f, player.transform.position.y, 0f) + offset;
    }
}

