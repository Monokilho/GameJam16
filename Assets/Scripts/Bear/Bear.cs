using UnityEngine;
using System.Collections.Generic;

public class Bear : MonoBehaviour {

    public List<Vector3> positions;

    bool moving;
    int nextlevel;
    int curlevel;
    float speed;
    float dist;
	// Use this for initialization
	void Start () {
        curlevel = 3;
       /* for (int i = 0; i < positions.Count; i++) {
            Debug.Log( positions[i].x);
            Debug.Log(Screen.width);
            Debug.Log(1980 / (Screen.currentResolution.width) * positions[i].x);
            positions[i] = new Vector3((Screen.width) /1980  * positions[i].x, positions[i].y, positions[i].z);
        }*/
        //transform.position = positions[3];
	}
	
	// Update is called once per frame
	void Update () {

        if (moving) {

            transform.position = Vector3.MoveTowards(transform.position, positions[nextlevel], (dist * speed));
            if (transform.position.x == positions[nextlevel].x)
            {
                moving = false;
                curlevel = nextlevel;
            }
        }
	}

   public void setLevel(int level) {
       
        nextlevel = level;
        dist = (positions[nextlevel] - positions[curlevel]).magnitude;

        moving = true;
    }

    public void setBearSpeed(float speed) {
        this.speed = speed;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            MainControl.BearHit();
            
        }

    }
}

