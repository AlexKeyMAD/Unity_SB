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
        panel.SetActive(false);

        levelText.text = $"Уровень {SceneManager.GetActiveScene().buildIndex.ToString()}";
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
}
