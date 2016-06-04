using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System;

public class Candy : MonoBehaviour, ISpawny
{

    public int movementspeed { get; set; }
    public int value { get; set; }
    public Spawner parent { get; set; }

    void Update()
    {


        if (gameObject.activeInHierarchy)
        {
            transform.Translate(new Vector2(-1 * movementspeed * Time.deltaTime, 0));
        }
    }

    public void fire()
    {
      
        gameObject.SetActive(true);
    }

    public void moveTo(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            MainControl.CandyHit();
        transform.position = new Vector2(0, 0);
        parent.reload(this);
        gameObject.SetActive(false);
    }
}
