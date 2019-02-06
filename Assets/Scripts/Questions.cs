using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEditor;

public class Questions : MonoBehaviour {
    public Text question;

    public string newQuestion()
    {
        
        string[] choices;
        string[] delimitors = {"  "};
        //loads question and correct answer from text file
        var api = Resources.Load("test") as TextAsset;
        var apiKey = api.text;
        AssetDatabase.Refresh();
        string[] lines = apiKey.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        int random = 1;
        while (random % 2 != 0)
        {
            random = UnityEngine.Random.Range(0, lines.Length);
        }

        choices = lines[random].Split('+');

        Debug.Log(lines[random]);
        foreach(String str in choices)
        {
             Debug.Log(str);
        }
       
        question.text = (choices[0] + "\n" + choices[1] + "\n" + choices[2] + "\n" + choices[3] + "\n" + choices[4]);

        return (lines[random + 1]);

    }
    
}
