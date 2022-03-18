using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareEnemy : MonoBehaviour
{
    //public AudioSource Ghost;
    public GameObject player;
    public GameObject JumpEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {

        if(collider.CompareTag("Player"))
        {
            StartCoroutine (EndJump());
        }
    }

    void OnTriggerExit(Collider collision)
    {

        if(collision.CompareTag("Player"))
        {
            Destroy(JumpEnemy.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds (1f);
        //Ghost.Play();
        JumpEnemy.SetActive(true);
        player.GetComponent<CharController>().enabled = false;

        yield return new WaitForSeconds (2f);
        JumpEnemy.SetActive(false);
        player.GetComponent<CharController>().enabled = true;
    }
}
