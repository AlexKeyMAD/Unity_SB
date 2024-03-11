using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    private Animator anim;
    public ParticleSystem ps;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        ps.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            anim.SetTrigger("Death");
    }

    public void Death()
    {
        ps.Play();
    }

    private void Update()
    {
        if (ps == null) 
            Destroy(transform.parent.gameObject);
    }
}
