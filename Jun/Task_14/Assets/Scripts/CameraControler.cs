using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    [SerializeField] private Transform playerTr;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTr.position;
    }

    private void FixedUpdate()
    {
        transform.position = playerTr.position + offset;
    }
}
