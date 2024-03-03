using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerScript : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField, Range(0, 10)] private int speed = 3;
    private Vector3 move;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horisont = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        move = new Vector3(horisont, 0, vertical).normalized;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerRB.AddForce(move * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            FindObjectOfType<PausePrefab>().GoToMenu();
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Reset values")]
    public void ResetValues()
    { 
        speed = 3;
    }
#endif
}
