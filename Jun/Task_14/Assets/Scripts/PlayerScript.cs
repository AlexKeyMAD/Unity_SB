using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerScript : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField, Range(0, 10)] private int speed = 3;
    private Vector3 move;
    public ParticleSystem ps;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();

        ps.Stop();
    }

    void Update()
    {
        float horisont = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        move = new Vector3(horisont, 0, vertical).normalized;

        if (ps == null)
            Destroy(gameObject);
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

        if (collision.gameObject.CompareTag("DeathZone"))
        {
            ps.Play();
            transform.localScale = new Vector3(.1f, .1f, .1f);
            GameOver();
        }
    }

    private void GameOver()
    {
        FindObjectOfType<PausePrefab>().GameOver();
    }

#if UNITY_EDITOR
    [ContextMenu("Reset values")]
    public void ResetValues()
    { 
        speed = 3;
    }
#endif
}
