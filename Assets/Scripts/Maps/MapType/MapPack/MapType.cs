using UnityEngine;
using System.Collections.Generic;

public class MapType : MonoBehaviour {



    System.Random rng;
    List<MapPack> mapspacks;
    List<MapScrolling> mapscrolling;
    int cur = 0;

    void Awake() {
        mapspacks = new List<MapPack>();
        mapscrolling = new List<MapScrolling>();
        foreach (Transform child in transform)
        {

            mapscrolling.Add(child.gameObject.GetComponent<MapScrolling>());
            mapspacks.Add(child.gameObject.GetComponent<MapPack>());
        }
        rng = new System.Random();


    }

    void Start() {

        for (int i = 1; i < mapspacks.Count; i++)
        {
            mapspacks[i].gameObject.SetActive(false);
        }

    }

    public void canSwitchAll(bool b) {
        foreach (MapScrolling mapscroll in mapscrolling) {
            mapscroll.canswitch = b;

        }

    }


    public void setTransitionSpeed(float s)
    {

        foreach (MapPack pack in mapspacks)
        {

            pack.setTransitionSpeed(s);

        }

    }

    public void setMoveSpeed(float s)
    {
        foreach (MapScrolling mapcrolling in mapscrolling)
        {

            mapcrolling.setMoveSpeed(s);

        }
       

    }

    public void setLevel(int level)
    {
        foreach (MapPack pack in mapspacks)
        {

            pack.setLevel(level);

        }

    }

    public void setFirstLevel(int level)
    {
        foreach (MapPack pack in mapspacks)
        {

            pack.setFirstLevel(level);

        }

    }


    void getNext(float x) {
        mapscrolling[cur].canswitch = false;
        MapScrolling nextpack = selectNextMap();
        nextpack.transform.position = new Vector3(x + 4800, nextpack.transform.position.y, nextpack.transform.position.z);
        nextpack.canswitch = true;
        nextpack.gameObject.SetActive(true);
    }

    MapScrolling selectNextMap()
    {
        int aux = 0;
 
        aux = cur;

        while ((cur = rng.Next(mapscrolling.Count)) == aux) ;
        return mapscrolling[cur];
    }

}
