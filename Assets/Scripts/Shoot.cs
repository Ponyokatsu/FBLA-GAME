using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject shot;
    private Transform playerpos;
    // Use this for initialization
    void Start()
    {

        playerpos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!PauseMenu.GameIsPaused && !dialogueManager.dialogueActive)
        {
            Vector3 mousePosition = Input.mousePosition;
            if (Vector2.Distance(transform.position, mousePosition) > 0.2f)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(shot, playerpos.position, Quaternion.identity);
                }
            }
        }
    }
   

float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
{
    return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
}



}