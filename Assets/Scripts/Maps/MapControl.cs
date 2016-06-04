using UnityEngine;
using System.Collections;

public class MapControl : MonoBehaviour
{

    public MapType background;
    public MapType foreground;
    public MapType terrain;

    // Use this for initialization
    void Start()
    {
        background.canSwitchAll(false);
        foreground.canSwitchAll(true);
        terrain.canSwitchAll(true);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void setTransitionSpeed(float s)
    {
        background.setTransitionSpeed(s);
        foreground.setTransitionSpeed(s);
        terrain.setTransitionSpeed(s);


    }

    public void setForegroundMoveSpeed(float s)
    {
        foreground.setMoveSpeed(s);

    }


    public void setTerrainMoveSpeed(float s)
    {
        terrain.setMoveSpeed(s);

    }

    public void setLevel(int level) {
        background.setLevel(level);
        foreground.setLevel(level);
        terrain.setLevel(level);

    }


    public void setFirstLevel(int level)
    {
        background.setFirstLevel(level);
        foreground.setFirstLevel(level);
        terrain.setFirstLevel(level);

    }
}
