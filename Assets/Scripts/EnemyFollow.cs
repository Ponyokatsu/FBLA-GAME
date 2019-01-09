using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFollow : MonoBehaviour {
    public float speed;
    private bool facingRight;
    private Transform target;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
        facingRight = true;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        if (target.position.x > transform.position.x && !facingRight || target.position.x < transform.position.x && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        if (Vector2.Distance(transform.position, target.position) < 20)
            {
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


            }
        }
    
}
