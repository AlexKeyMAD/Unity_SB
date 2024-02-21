using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void Task1()
    {
        ChangeScene("Task1_Scene");
    }
    public void Task2()
    {
        ChangeScene("Task2_Scene");
    }
    public void MainMenu()
    {
        ChangeScene("MainScene");
    }

    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
