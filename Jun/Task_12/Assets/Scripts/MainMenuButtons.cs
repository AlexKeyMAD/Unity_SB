using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject menuCanvas;

    void Start()
    {
        startCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void OpenSelectLevels()
    {
        startCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StarLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

}
