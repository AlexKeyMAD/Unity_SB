using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{
    public int MaxTimer;
    public bool Step;

    private Image img;
    private float CurTime;

    void Start()
    {
        img = GetComponent<Image>();
        CurTime = 0;
    }

    void Update()
    {
        Step = false;

        CurTime += Time.deltaTime;

        if (CurTime >= MaxTimer)
        {
            Step = true;
            CurTime = 0; 
        }

        img.fillAmount = CurTime / MaxTimer;
    }
}
