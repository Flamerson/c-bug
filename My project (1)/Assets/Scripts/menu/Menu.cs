using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public string SceneName;
    [SerializeField] public string SceneName1;
    [SerializeField] private GameObject selectPersonPanel;
    [SerializeField] private GameObject menuPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void PlayGameGirl()
    {
        SceneManager.LoadScene(SceneName1);
    }

    public void OpenSelectPerson()
    {
        menuPanel.SetActive(false);
        selectPersonPanel.SetActive(true);
    }

    public void ExitSelectPerson()
    {
        selectPersonPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
