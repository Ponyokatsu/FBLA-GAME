
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float startHealth;
    public float health;
    public Text healthDisplay;
    public GameObject gameOverUI;
    private Rigidbody2D myRigidBody;
    public Image healthBar;
    public Animator animator;
    public bool ani;

    // Update is called once per frame
    void Start()
    {
        ani = false;
        health = startHealth;
    }
    
    void FixedUpdate()
    {
        if (!PauseMenu.GameIsPaused && !dialogueManager.dialogueActive)
        { if (Input.GetAxisRaw("Horizontal") > -.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
              //  AudioManager.instance.Play("footsteps");
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            }
            if (Input.GetAxisRaw("Vertical") > -.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
              //  AudioManager.instance.Play("footsteps");
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            }
            if (health <= 0)
            {
                GameOver();
            }
            healthDisplay.text = "HEALTH: " + health;
        }
        
    }
    public void GameOver()
    {
        Debug.Log("test");
        AudioManager.instance.Stop();
        AudioManager.instance.Play("Defeat");
        UponLoadTitle.streak = 0;
        gameOverUI.SetActive(true);
        animator.SetTrigger("Die");
        Destroy(gameObject, 1.0f);
    }
    

    

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("hit");
        if (other.CompareTag("Enemy"))
        {
            health--;
            Destroy(other.gameObject);
            healthBar.fillAmount = health / startHealth;
        }
       
    }

}

    
    

