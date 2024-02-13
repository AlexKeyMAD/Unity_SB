using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource sourse;

    public void ButtonClick()
    {
        sourse.clip = sounds[0];
        sourse.loop = false;
        sourse.Play();
    }

    public void Harvest()
    {
        sourse.clip = sounds[1];
        sourse.loop = false;
        sourse.Play();
    }

    public void Eat()
    {
        sourse.clip = sounds[2];
        sourse.loop = false;
        sourse.Play();
    }

    public void Combat()
    {
        sourse.clip = sounds[3];
        sourse.loop = false;
        sourse.Play();
    }

    public AudioClip GetWin()
    {
        return sounds[4];
    }

    public AudioClip GetLoss()
    {
        return sounds[5];
    }

    public void Countryman()
    {
        sourse.clip = sounds[6];
        sourse.loop = false;
        sourse.Play();
    }

    public void Warrior()
    {
        sourse.clip = sounds[7];
        sourse.loop = false;
        sourse.Play();
    }
}
