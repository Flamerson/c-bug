using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDeath : MonoBehaviour
{

    public GameObject restart;
    public GameObject sound;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            sound.GetComponent<AudioSource>().Stop();
            RestartScene();
        }
    }


    public void RestartScene(){
        restart.SetActive(true);
    }
}
