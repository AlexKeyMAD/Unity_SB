using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OpenFirstTask()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void OpenSecondTask()
    {
        SceneManager.LoadScene("SecondScene");
    }
}
