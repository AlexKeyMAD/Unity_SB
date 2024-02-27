using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandyScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(transform.position);

        var v = transform.rotation.eulerAngles;
        v.y += transform.rotation.y > 0 ? 20f : -20f;

        transform.rotation = Quaternion.Euler(v);
    }
}
