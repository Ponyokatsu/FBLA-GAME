using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UponLoadTitle : MonoBehaviour {
    public static int streak = 0;
    public Text streakTxt;
    public GameObject victory;
	//loads music and sets streak every time the menu is loaded
	void Start () {
        AudioManager.instance.Play("Title");
        streakTxt.text = "Current streak: " + streak;

        if (streak == 3)
        {
            victory.SetActive(true);
        }
	}

    
}
