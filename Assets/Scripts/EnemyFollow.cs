using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFollow : MonoBehaviour {
    public float speed;
    private Transform target;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
        if (GameObject.Find("spriteEx") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
	}
	
	// Update is called once per frame
	void Update () {

        
        if (GameObject.Find("spriteEx") != null && Vector2.Distance(transform.position, target.position) < 20 && !PauseMenu.GameIsPaused && !dialogueManager.dialogueActive)
            {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.up = direction;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        
	}

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Projectile"))
            {

                explosion = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
                Destroy(explosion, 1.0f);
                Destroy(gameObject);
                Destroy(other);


            }
        }
    
}
