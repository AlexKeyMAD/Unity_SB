using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsScript : MonoBehaviour
{
    private Animator an;

    private void Awake()
    {
        an = GetComponent<Animator>();
    }

    public void UpdateState()
    {
        an.SetInteger("State", Random.Range(0, 3));
    }

}
