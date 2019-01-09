using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fadeToLevel : MonoBehaviour
{
    public Animator animator;
    public string levelToLoad;
    
    // Update is called once per frame

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
