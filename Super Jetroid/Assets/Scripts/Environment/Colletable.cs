﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {

        if (target.gameObject.tag == "Player") { Destroy(this.gameObject); }
            
    }
}
