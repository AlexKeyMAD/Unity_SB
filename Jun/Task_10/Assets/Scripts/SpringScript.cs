using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    [SerializeField] private float force;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Vector3 v = new Vector3(Random.Range(-1.5f, 1.5f), 0, Random.Range(0f, 2f));

            Debug.Log(v.ToString());

            collision.rigidbody.AddForce(v * force, ForceMode.Impulse);
        }
    }
}
