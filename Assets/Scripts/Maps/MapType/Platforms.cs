using UnityEngine;
using System.Collections.Generic;

public class Platforms : MonoBehaviour {

    List<GameObject> platforms;
    int cur;

    void Awake() {
        platforms = new List<GameObject>();

        foreach (Transform child in transform) {
            platforms.Add(child.gameObject);
        }

    }


    public void setFirstLevel(int level) {
        for (int i = 0; i < platforms.Count; i++) {
            if (i == level)
                platforms[i].SetActive(true);
            else
                platforms[i].SetActive(false);

        }
        cur = level;
    }
    public void setLevel(int level) {
        platforms[cur].SetActive(false);
        platforms[level].SetActive(true);
        cur = level;
    }
}
