using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System;

public class Enemy : MonoBehaviour, ISpawny
{
    System.Random rng = new System.Random();
    // movement and collision  
    public Spawner parent { get; set; }
    public int movementspeed { get; set; }
    int curspeed = 0;
    public int value { get; set; }
    // sprite control
    List<SpriteRenderer> sprites;
    public float transitionspeed { get; set; }
    bool switching;
    int curlevel;
    int nextlevel;



    void Awake()
    {
        sprites = new List<SpriteRenderer>();
        foreach (Transform child in transform)
        {
            sprites.Add(child.GetComponent<SpriteRenderer>());
        }
    }

    void Update()
    {

        // Enemy Movement
        if (gameObject.activeInHierarchy)
        {
            transform.Translate(new Vector2(-1 * curspeed * Time.deltaTime, 0));
        }
        // Enemy Sprite Change
        if (switching)
        {
            FadeOut(sprites[curlevel]);
            if (FadeIn(sprites[nextlevel]))
            {
                curlevel = nextlevel;
                switching = false;
            }
        }
    }



    // MOVEMENT AND COLLISION
    public void fire()
    {
        curspeed = rng.Next(movementspeed, movementspeed + 500);
        gameObject.SetActive(true);
    }

    public void moveTo(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            MainControl.EnemyHit();
            other.gameObject.SendMessage("Hit");
        }
        if (switching) {
            Hide(sprites[curlevel]);
            Show(sprites[nextlevel]);
            curlevel = nextlevel;
            switching = false;
        }
        transform.position = new Vector2(0, 0);
        parent.reload(this);
        gameObject.SetActive(false);
    }

    //SPRITE CHANGER

    void Show(SpriteRenderer sprite)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
    }
    void Hide(SpriteRenderer sprite)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
    }
    bool FadeIn(SpriteRenderer sprite)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a + transitionspeed);

        if (sprite.color.a >= 1)
            return true;
        return false;
    }
    void FadeOut(SpriteRenderer sprite)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - transitionspeed);

        
    }

    public void setFirstLevel(int level)
    {

        for (int i = 0; i < sprites.Count; i++)
        {
            if (i == level)
                Show(sprites[i]);
            else
                Hide(sprites[i]);
        }
        curlevel = nextlevel = level;
    }

    public void setLevel(int level)
    { 
        if (isActiveAndEnabled)
        {
            nextlevel = level;
            switching = true;
        }
        else {
            Hide(sprites[curlevel]);
            Show(sprites[level]);
            curlevel = nextlevel = level;
        }

    }
}
