using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used to follow the player for stricly vertical levels
public class FollowPlayer : MonoBehaviour
{
    private GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    private bool foundPlayer = false;

    void Start()
    {
        //player = GameObject.Find("Player(Clone)");
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        
    }


    private void Update()
    {

        if (!player)
        {
            player = GameObject.Find("Player(Clone)");
            if (player) { 
            transform.position = player.transform.position;
            offset = new Vector3(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y, -10f);
            }
        }


    }

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (player)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0f) + offset;
        }
    }
}

