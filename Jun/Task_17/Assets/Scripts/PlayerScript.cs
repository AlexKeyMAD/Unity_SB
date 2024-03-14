using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField, Range(0, 20)] private int speed = 3;
    public Animator anim;
    public SpriteRenderer playerSR;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float horisont = Input.GetAxis("Horizontal");

        bool run = false;

        if (Input.GetKey(KeyCode.LeftShift)) run = true;

        MovePlayer(horisont, run);
    }

    private void MovePlayer(float horisont, bool run)
    {
        anim.SetBool("Walk", !run && horisont != 0);
        anim.SetBool("Run", run && horisont != 0);
        if (horisont != 0)
        {
            playerSR.flipX = horisont < 0;
            playerRB.MovePosition(playerRB.position + Vector2.right * horisont * (speed * (run ? 2 : 1)) * Time.deltaTime);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Reset values")]
    public void ResetValues()
    {
        speed = 8;
    }
#endif
}
