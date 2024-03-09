using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log(SceneManager.sceneCountInBuildSettings);

        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }
}
