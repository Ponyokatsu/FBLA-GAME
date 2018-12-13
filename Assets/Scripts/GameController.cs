﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject target;
    private BoardingParty selector;
    public int level = 1;
    public int[] assignment = new int[] { 0, 0, 0, 0 };
    public string goodAns;
    private Transform enemyPos;
    
	// Use this for initialization
    
    void Start()
    {
        
        enemyPos = GameObject.Find("EnemyBig").GetComponent<Transform>();
        for (int i = 0; i < 3; i++)
        {

            Instantiate(target, enemyPos.position, Quaternion.identity);
        }

        Dialogue dialogue = new Dialogue (new string[] {"This is the Admiral. There is a large enemy ship ahead that we need you to destroy","Good Luck"},"Admiral Cryane");
       
       FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
        
        

		
	}
    
	
	// Update is called once per frame
	void Update () {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        if (enemies.Length <= 0 && level==1)
        {
            level = 2;
            stageTwo();
        }


        

        


	}

     


   
    public void stageTwo()
    {
         goodAns = newQuestion();
        int rand = (Random.Range(1,4));
        
        for (int i = 0; i < assignment.Length; i++)
        {
            while(assignment[i] == 0)
            {
                rand = (char)(Random.Range(65, 69));
                bool taken = false;
                for (int k = 0; k < assignment.Length; k++)
                {
                    if (assignment[k] == rand) { taken = true; }
                    
                }
                if (!taken)
                {
                    assignment[i] = rand;
                    
                }
            }
        }


        GameObject party = GameObject.Find("one");
        BoardingParty partyScript = party.GetComponent<BoardingParty>();
        partyScript.active = true;

         party = GameObject.Find("two");
         partyScript = party.GetComponent<BoardingParty>();
        partyScript.active = true;

        party = GameObject.Find("three");
        partyScript = party.GetComponent<BoardingParty>();
        partyScript.active = true;

        party = GameObject.Find("four");
        partyScript = party.GetComponent<BoardingParty>();
        partyScript.active = true;


        
     }


    public void checkAns(string name)
    {
        if (System.Convert.ToChar(assignment[(int.Parse(name)) - 1]) == System.Convert.ToChar(goodAns))
        {
            
                SceneManager.LoadScene("InsideShip");
            
        }
        else
        {

            
            gameOver();

        }
    }

    
    public void gameOver()
    {
        
        SceneManager.LoadScene("GameOver");
    }

    static string newQuestion()
    {
        

        string path = "Assets/Resources/test.txt";
        string[] lines = System.IO.File.ReadAllLines(path);

        int random=1;
        while (random % 2 != 0)
        {
            random = Random.Range(0, lines.Length);
        }

        Text question = GameObject.Find("question").GetComponent<Text>();
         
        question.text = lines[random];
        Debug.Log(lines[random + 1]);
         return (lines[random + 1]);
       
    }
}
