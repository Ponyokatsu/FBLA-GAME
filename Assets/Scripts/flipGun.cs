using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipGun : MonoBehaviour
{
    
    private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            theScale.y *= -1;
            transform.localScale = theScale;
        }
    }
}
