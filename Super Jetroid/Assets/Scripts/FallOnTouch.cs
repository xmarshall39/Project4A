﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnTouch : MonoBehaviour
{
    public float fallDelay = 0.3f;
    private IEnumerator coroutine;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            coroutine = WaitAndFall();
            StartCoroutine(coroutine);
        }
    }

    IEnumerator WaitAndFall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        print("Falling now");
    }
}
