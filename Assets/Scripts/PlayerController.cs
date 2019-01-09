﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float startHealth;
    private float health;
    public Text healthDisplay;
    public GameObject gameOverUI;
    private Rigidbody2D myRigidBody;
    private bool facingRight;
    public Image healthBar;
 

    // Update is called once per frame
    void Start()
    {
        health = startHealth;
        facingRight = true;
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {

        if (Input.GetAxisRaw("Horizontal") > -.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > -.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            }
        if (health <= 0)
        {

            gameOverUI.SetActive(true);
        }
        healthDisplay.text = "HEALTH: " + health;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            health--;
            Destroy(other.gameObject);
            healthBar.fillAmount = health / startHealth;
        }
    }
}
