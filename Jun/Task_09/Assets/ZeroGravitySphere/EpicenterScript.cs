using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicenterScript : MonoBehaviour
{
    private float deltaTime = 4;

    public float radius;
    public int power;
    

    private void FixedUpdate()
    {
        deltaTime -= Time.deltaTime;

        if (deltaTime < 0)
        {
            BadaBoom();
        }
    }

    private void BadaBoom()
    {
        Rigidbody[] victims = FindObjectsOfType<Rigidbody>();

        foreach (var v in victims)
        {
            var dist = Vector3.Distance(transform.position, v.transform.position);

            if (dist < radius)
            {
                var dir = v.transform.position - transform.position;

                v.AddForce(dir * power * (radius - dist),ForceMode.Impulse);
            }

        }

        deltaTime = 2;
    }
}
