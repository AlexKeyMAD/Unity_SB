using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : MonoBehaviour
{
    public GameObject target;
    public int speed;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(target.transform.position * speed,ForceMode.Impulse);
    }

    
}
