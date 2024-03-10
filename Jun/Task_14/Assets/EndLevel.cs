using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int ind = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(ind + 1);
    }
}
