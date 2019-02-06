using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour {
    public GameObject shot;
    private Transform target;
    private float count;

    // Use this for initialization
    void Start () {
        if (GameObject.Find("spriteEx") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        count = 0;
        
    }

    // Update is called once per frame
     void Update()
    {
        //Instantiate(shot, transform.position, Quaternion.identity);
        if (GameObject.Find("spriteEx") != null && Vector2.Distance(transform.position, target.position) < 20 && !PauseMenu.GameIsPaused && !dialogueManager.dialogueActive)
        {
            count += Time.deltaTime;
            if (count > (2/(UponLoadTitle.streak + 1)+0.5)) { 
            Instantiate(shot, transform.position, Quaternion.identity);
                count = 0;
            }
           
        }
    
    }
        
    
}
