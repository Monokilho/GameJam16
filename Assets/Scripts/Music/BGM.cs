using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGM : MonoBehaviour {


    public AudioClip[] BGMclips;
    List<AudioSource> bgms;

    public int statechanging;
    public int current;
    float transitionspeed;

	// Use this for initialization
	void Start () {
        bgms = new List<AudioSource>();
        foreach (AudioClip clip in BGMclips) {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = true;
            source.Play();
            source.volume = 0f;
            bgms.Add(source);
        }
        if (bgms.Count != 0)
        {
            bgms[0].volume = 1f;
            bgms[3].Stop();
        }

	}




	// Update is called once per frame
	void Update () {

        switch (statechanging)
        {
            case 1:
                HappyToNormal();
                break;
            case 2:
                NormalToHappy();
                break;
            case 3:
                NormalToMad();
                break;
            case 4:
                MadToNormal();
                break;
        }

    }

    void HappyToNormal()
    {
        raise(bgms[1]);
        lower(bgms[0]);
        if (bgms[1].volume >= 1) {
            statechanging = 0;
        }
    }

    void NormalToHappy()
    {
        raise(bgms[0]);
        lower(bgms[1]);
        if (bgms[0].volume >= 1)
        {
            statechanging = 0;
        }

    }
    void MadToNormal()
    {
        raise(bgms[1]);
        lower(bgms[2]);
        if (bgms[1].volume >= 1)
        {
            statechanging = 0;
        }

    }
    void NormalToMad()
    {
        raise(bgms[2]);
        lower(bgms[1]);
        if (bgms[2].volume >= 1)
        {
            statechanging = 0;
        }

    }


    void raise(AudioSource source) {

        source.volume += transitionspeed;

    }

    void lower(AudioSource source)
    {
        source.volume -= transitionspeed;

    }

    public void setTransitionState(int s) {
        statechanging = s;

    }

    public void setTransitionSpeed(float s) {

        transitionspeed = s;
    }

    public void setLevel(int level) {

        statechanging = level;
        current = level;
    }

    public void playGameOver() {
        bgms[current].Stop();
        bgms[3].volume = 1f;
        bgms[3].Play();

    }

}
