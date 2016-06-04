using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapScrolling : MonoBehaviour
{

    float speed = 0f;
    public bool canswitch { get;set;}
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
     
        transform.Translate(new Vector2(-1 * speed * Time.deltaTime, 0));
        if (transform.position.x <= 200 && canswitch)
        {
            GetComponentInParent<MapType>().SendMessage("getNext", transform.position.x);
        }
    }

    void Restart()
    {
        if (enabled)
        {
            gameObject.SetActive(false);
        }
    }

    public void setMoveSpeed(float s)
    {

        speed = s;

    }
}
