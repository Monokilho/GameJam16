using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SFX : MonoBehaviour
{


    public enum sfx_codes { bitbearhit, candy, headbump, jump, land, hit }

    public AudioClip[] BGMclips;
    List<AudioSource> sfx;

    void Start()
    {
        sfx = new List<AudioSource>();
        foreach (AudioClip clip in BGMclips)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            sfx.Add(source);
        }
    }

    public void playsound(int code)
    {
        sfx[code].Play();

    }


}
