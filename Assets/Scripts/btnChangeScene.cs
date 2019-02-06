using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnChangeScene : MonoBehaviour {

    //used by buttons to change scenes
	public void ChangeScene (string scene) {

        AudioManager.instance.Stop();
    
        SceneManager.LoadScene(scene);
		
	}
    //called by quit button to quit application
    public void Quit()
    {
        Application.Quit();

    }
    //plays the button sound
    public void btnSound()
    {
        AudioManager.instance.Play("Button");
    }

    
}
