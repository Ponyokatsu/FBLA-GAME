using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{

    public GameObject player;
    private bool thing;
    public GameObject explosion;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Stop();
        AudioManager.instance.Play("End");
        UponLoadTitle.streak++;
        StartCoroutine(delay());
    }

    // Update is called once per frame
    void Update()
    {

        if (thing)
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(-36, -55, 0), 10 * Time.deltaTime);
    }


    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        thing = true;
        yield return new WaitForSeconds(0.4f);
        Instantiate(explosion, GameObject.Find("EnemyBig").transform.position, Quaternion.identity);
        Destroy(GameObject.Find("EnemyBig"));
        yield return new WaitForSeconds(1.6f);
        animator.SetTrigger("fade_out");
        yield return new WaitForSeconds(1f);
        AudioManager.instance.Stop();
        SceneManager.LoadScene("Menu");
    }
}
