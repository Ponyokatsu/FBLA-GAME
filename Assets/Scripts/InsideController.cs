using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideController : MonoBehaviour {
    public string goodAns;
    
    // Use this for initialization
    void Start () {
        GameObject.Find("name").SetActive(true);
        GameController.level = 3;
        AudioManager.instance.playRand();
        if (Settings.dialogueToggle)
        {
            Dialogue dialogue;
            if (SceneManager.GetActiveScene().name.Equals("InsideShipNew"))
            {
                GameObject.Find("name").SetActive(true);
                 dialogue = new Dialogue(new string[] { "Congratulations for making it this far", "You have now boarded the enemy", "Use the new intel provided to find the hatch to the engine room", "Once you get there, plant the chargeand get out of there!" }, "-Captain Cryane");
                FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
            }
          
           
        }
        else
        {
            GameObject.Find("next").SetActive(false);
            GameObject.Find("name").SetActive(false);
            goodAns = GetComponent<Questions>().newQuestion();
        }
	}
	

}
