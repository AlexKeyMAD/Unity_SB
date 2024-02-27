using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    [SerializeField] private float timeSpring;

    private float curTime;

    private bool shoot;

    private void Update()
    {
        curTime += Time.deltaTime;

        if (curTime >= timeSpring)
        {
            curTime = 0;
            PullSpring();

            shoot = true;
        }
    }

    private void PullSpring()
    {
        var v = transform.position;
        v.z -= 1.2f;

        transform.position = Vector3.MoveTowards(transform.position, v, 2f); 
    }

    private void OnCollisionExit(Collision collision)
    {
        if (shoot)
        {
            Debug.Log(collision.rigidbody.velocity);
            collision.rigidbody.velocity *= 10;
            Debug.Log(collision.rigidbody.velocity);
            
            collision.rigidbody.AddForce(collision.rigidbody.velocity,ForceMode.VelocityChange);
            
        }
    }
}
