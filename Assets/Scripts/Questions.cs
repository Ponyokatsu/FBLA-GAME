using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class Questions : MonoBehaviour {
    public Text question;

    public string newQuestion()
    {
        //loads question and correct answer from text file
        var api = Resources.Load("test") as TextAsset;
        var apiKey = api.text;
        string[] lines = apiKey.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        int random = 1;
        while (random % 2 != 0)
        {
            random = UnityEngine.Random.Range(0, lines.Length);
        }


        question.text = lines[random];

        return (lines[random + 1]);

    }
    
}
