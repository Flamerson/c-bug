using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class faseManager : MonoBehaviour
{
    public string SceneName;

    public void RestartScene(){
        SceneManager.LoadScene(SceneName);
    }

}
