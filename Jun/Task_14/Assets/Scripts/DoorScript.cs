using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().AddTorque(Vector3.back * 2, ForceMode.VelocityChange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            NextLevel();
    }

    public void NextLevel()
    {
        int ind = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(ind);
        //if (ind + 1 >= SceneManager.sceneCountInBuildSettings) SceneManager.LoadScene(0); 
        //else
        SceneManager.LoadScene(ind + 1);
    }
}
