
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable()]
public class Score 
{

    public string name { get; set; }

     public float points { get; set; }

    public Score(string name, float val)
    {
        this.name = name;
        this.points = val;
    }

   
  


}
