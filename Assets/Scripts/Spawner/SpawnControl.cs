using UnityEngine;

using System.Collections;
using System;

public class SpawnControl : MonoBehaviour {

    int maxspawnheight = 460;
    int minspawnheight = 50;
    int groundspawnHeight = -220;

    public Spawner candyspawner;
    public Spawner airspawner;
    public Spawner groundspawner;


    System.Random rand = new System.Random();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void fireCandy()
    {
        StartCoroutine("fireCandyPriv");
    }

    public void fireAir()
    {
        StartCoroutine("fireAirPriv");

    }

    public void fireGround()
    {
        StartCoroutine("fireGroundPriv");

    }

     void fireCandyPriv() {
        float y = rand.Next(minspawnheight, maxspawnheight);
        float x = transform.position.x;
        candyspawner.fire(x,y);
    }

     void fireAirPriv() {
        float y = rand.Next(minspawnheight, maxspawnheight);
        float x = transform.position.x;
        airspawner.fire(x, y);

    }

     void fireGroundPriv() {
        float y = groundspawnHeight;
        float x = transform.position.x;
        groundspawner.fire(x, y);

    }



    public void setCandySpeed(int s) {
        candyspawner.setMoveSpeed(s);
    }

    public void setCandyValue(int v)
    {
        candyspawner.setValue(v);
    }

    public void setAirEnemyTransitionSpeed(float s) {
        airspawner.setTransitionSpeed(s);
    }

    public void setAirEnemyMoveSpeed(int s)
    {
        airspawner.setMoveSpeed(s);
    }

    public void setAirEnemydmg(int v)
    {
        airspawner.setValue(v);
    }

    public void setGroundEnemyTransitionSpeed(float s)
    { 
       groundspawner.setTransitionSpeed(s);
    }

    public void setGroundEnemyMoveSpeed(int s)
    {
       groundspawner.setMoveSpeed(s);
    }

    public void setGroundEnemydmg(int v) {
        airspawner.setValue(v);
    }

    public void setTransitionSpeed(float s) {
        groundspawner.setTransitionSpeed(s);
        airspawner.setTransitionSpeed(s);
    }

    public void setLevel(int level) {
        airspawner.setLevel(level);
        groundspawner.setLevel(level);
    }

    public void setFirstLevel(int level)
    {
        airspawner.setFirstLevel(level);
        groundspawner.setFirstLevel(level);
    }
}
