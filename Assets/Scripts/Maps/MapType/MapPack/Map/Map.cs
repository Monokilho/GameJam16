using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{


    SpriteRenderer mapsprite;

    public bool StartActive;

    void Awake()
    {

        mapsprite = gameObject.GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {

    }

    public bool FadeIn(float s)
    {
        mapsprite.color = new Color(mapsprite.color.r, mapsprite.color.g, mapsprite.color.b, mapsprite.color.a + s);
        if (mapsprite.color.a >= 1)
            return true;
        return false;

    }

    public void FadeOut(float s)
    {
        mapsprite.color = new Color(mapsprite.color.r, mapsprite.color.g, mapsprite.color.b, mapsprite.color.a - s);
    }

    public void Hide()
    {
        mapsprite.color = new Color(mapsprite.color.r, mapsprite.color.g, mapsprite.color.b,0f);
    }


    public void Show()
    {
        mapsprite.color = new Color(mapsprite.color.r, mapsprite.color.g, mapsprite.color.b, 1f);
    }
    void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
        {
            
           transform.parent.SendMessage("Restart");
        
        }
    }

}
