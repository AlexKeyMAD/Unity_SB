using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public int power;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Contains("Earth"))
        {
            Vector3 d = collision.transform.position - transform.position;

            collision.rigidbody.AddForce(d.normalized * power, ForceMode.Impulse);
        }
    }

}
