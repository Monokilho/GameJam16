using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{

     Stack<ISpawny> ready_spawny;
     List<ISpawny> all_spawny;
    public GameObject[] prefabs;
    public int unit_ammount;
    void Awake()
    {
        ready_spawny = new Stack<ISpawny>();
        all_spawny = new List<ISpawny>();

        for (int i = 0; i < unit_ammount; i++)
        {
            foreach (GameObject obj in prefabs)
            {
                GameObject newobj = (GameObject)Instantiate(obj,transform.position,Quaternion.identity);
                newobj.SetActive(false);     
                newobj.transform.parent = gameObject.transform;
                ISpawny spawn = newobj.GetComponent<ISpawny>();
                spawn.parent = this;
                ready_spawny.Push(newobj.GetComponent<ISpawny>());
                all_spawny.Add(newobj.GetComponent<ISpawny>());
            }
        }
    }



    public void fire(float x, float y)
    {
        if (ready_spawny.Count == 0)
            return;
        ISpawny spawny = ready_spawny.Pop();
        spawny.moveTo(x, y, -3);
        spawny.fire();

    }

   public void reload(ISpawny spawn) {
        ready_spawny.Push(spawn);
    }

    public void setMoveSpeed(int s)
    {
        foreach (ISpawny child in all_spawny)
        {
            child.movementspeed = s;
        }
    }

    public void setTransitionSpeed(float s)
    {
        foreach (ISpawny child in all_spawny)
        {
            ((Enemy)child).transitionspeed = s;
        }
    }

    public void setLevel(int level)
    {
        foreach (ISpawny child in all_spawny)
        {
            ((Enemy)child).setLevel(level);
        }
    }

    public void setFirstLevel(int level)
    {
        foreach (ISpawny child in all_spawny)
        {
            ((Enemy)child).setFirstLevel(level);
        }
    }

    public void setValue(int v)
    {
        foreach (ISpawny child in all_spawny)
        {
            child.value = v;
        }

    }
}