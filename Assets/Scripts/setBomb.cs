using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setBomb : MonoBehaviour
{
    public Animator animator;
    public GameObject bomb;
    public GameObject button;
    public GameObject player;
    
    public void SetBomb()
    {
        animator.SetTrigger("FadeIn");

        StartCoroutine(Wait());
        
    }
    
  
    IEnumerator Wait()
    {
      
        yield return new WaitForSeconds(.5f);
        bomb.SetActive(true);
        button.SetActive(false);
        player.SetActive(false);
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("FadeOut");
    }
}
