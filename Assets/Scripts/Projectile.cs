﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed;
    Vector3 mousePosition;
    Vector3 direction;
    public Transform target;
    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0F;
       
       
   
        direction = (mousePosition - transform.position).normalized;
        Destroy(gameObject, 2.0f);
    }

    void Update()
    {
        

        transform.up = direction;
        transform.position += direction * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("boardingParty") || other.CompareTag("Wall") || other.CompareTag("Rooms"))
        {
            Destroy(gameObject);
            
        }
    }
    
    
}
