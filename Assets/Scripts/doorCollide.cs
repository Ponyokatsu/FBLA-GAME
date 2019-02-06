using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorCollide : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject door;

     void Start()
    {
   
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(GameObject.Find("GameController").GetComponent<InsideController>().goodAns);
     if (other.CompareTag("Player"))
        {
            Debug.Log("ksfksf");
            string ans = GameObject.Find("GameController").GetComponent<InsideController>().goodAns;
            if (tag.Equals(ans))
            {
                SceneManager.LoadScene("reactor");
             
            }
            else
            {

                GameObject.Find("spriteEx").GetComponent<PlayerController>().GameOver();

            }
        }
        }

}

