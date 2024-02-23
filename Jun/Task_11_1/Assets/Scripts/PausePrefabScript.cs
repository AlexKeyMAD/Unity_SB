using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePrefab : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void GamePause()
    {
        Time.timeScale = 0;

        panel.SetActive(true);
    }
}
