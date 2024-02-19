using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttom : MonoBehaviour
{

    public void Superman()
    {
        LoadScene("Superman");
    }

    public void Billiards()
    {
        LoadScene("Billiards");
    }

    public void ZeroGravitySphere()
    {
        LoadScene("ZeroGravitySphere");
    }

    public void BackToMainMenu()
    {
        LoadScene("MainScene");
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
