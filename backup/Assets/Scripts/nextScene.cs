using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public string SceneName;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            RestartScene();
        }
    }


    public void RestartScene(){
        SceneManager.LoadScene(SceneName);
    }
}
