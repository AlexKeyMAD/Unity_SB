using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public Vector3[] positions;
    public float speed;

    private bool forward = true;
    private int index = 0;

    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (forward && index == positions.Length - 1) forward = false;
        else if (!forward && index == 0) forward = true;

        transform.position = Vector3.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index])
        {
            if (forward) index++;
            else index--;
        }

    }
}
