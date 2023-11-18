using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour
{
    public string SceneName;
    public GameObject pause;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            pause.SetActive(true);
        }
    }

    public void FecharMenu(){
        pause.SetActive(false);
    }

    public void RestartScene(){
        SceneManager.LoadScene(SceneName);
    }
}
