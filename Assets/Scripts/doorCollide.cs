using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorCollide : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject door;
     public string loadLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(GameObject.Find("GameController").GetComponent<InsideController>().goodAns);
        if (other.CompareTag("Player"))
        {

            if (GameObject.Find("GameController").GetComponent<Questions>().ans.Equals("A") && door.name.Equals("ansA"))
            {
                SceneManager.LoadScene(loadLevel);
            }
            else if (GameObject.Find("GameController").GetComponent<Questions>().ans.Equals("B") && door.name.Equals("ansB"))
            {
                SceneManager.LoadScene(loadLevel);
            }
            else if (GameObject.Find("GameController").GetComponent<Questions>().ans.Equals("C") && door.name.Equals("ansC"))
            {
                SceneManager.LoadScene(loadLevel);
            }
            else if (GameObject.Find("GameController").GetComponent<Questions>().ans.Equals("D") && door.name.Equals("ansD"))
            {
                SceneManager.LoadScene(loadLevel);
            }
            else { gameOverUI.SetActive(true); }

        }
        }

}

/*
public class doorCollide : MonoBehaviour
{
    private string loadlevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

            SceneManager.LoadScene("InsideShip2");
    }
}
*/
