using UnityEngine;
using System.Collections.Generic;
using System;

public class MapPack : MonoBehaviour
{




    public float transparency;
    public Map happy_map;
    public Map normal_map;
    public Map mad_map;
    public Platforms platforms;

    List<Map> maps;
    float transitionspeed;
    int curlevel;
    int nextlevel;
    bool switching;

    void Awake()
    {
        maps = new List<Map>();
        foreach (Transform child in transform)
        {
            Debug.Log(name);
            Map map = child.GetComponent<Map>();
            if (map != null)

                maps.Add(map);
            Debug.Log(maps.Count);
        }
        curlevel = 0;
        switching = false;
        nextlevel = curlevel;
    }


    // Update is called once per frame
    void Update()
    {
        if (switching)
        {
            maps[curlevel].FadeOut(transitionspeed);
            if (maps[nextlevel].FadeIn(transitionspeed))
            {
                switching = false;
                curlevel = nextlevel;
            }
        }

    }

    public void setLevel(int level)
    {
        if (isActiveAndEnabled)
        {
            nextlevel = level;
            switching = true;
        }
        else {
            maps[curlevel].Hide();
            maps[level].Show();
            curlevel = nextlevel = level;
        }
        if (platforms != null)
            platforms.setLevel(level);

    }

    public void setTransitionSpeed(float s)
    {

        transitionspeed = s;
    }

    public void setFirstLevel(int level)
    {
        for (int i = 0; i < maps.Count; i++)
        {
            if (i == level)
                maps[i].Show();
            else
                maps[i].Hide();
        }
        if (platforms != null)
            platforms.setFirstLevel(level);
        curlevel = nextlevel = level;
    }

    void Restart()
    {

        if (switching)
        {
            maps[curlevel].Hide();
            maps[nextlevel].Show();
            switching = false;
            curlevel = nextlevel;

        }
    }
}
