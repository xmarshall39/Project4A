using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = .5f;
    Rigidbody2D RBody;


    // Start is called before the first frame update
    void Start()
    {
        RBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
}
