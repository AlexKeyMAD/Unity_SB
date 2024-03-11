using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePrefab : MonoBehaviour
{
    public GameObject panel;
    public Text levelText;

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);

            levelText.text = $"Уровень {SceneManager.GetActiveScene().buildIndex.ToString()}";
        }
    }

    public void GamePause()
    {
        Time.timeScale = 0;

        panel.SetActive(true);
    }

    public void BackToGame()
    {
        Time.timeScale = 1;

        panel.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
}
