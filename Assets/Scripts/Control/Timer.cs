using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    public SpawnControl firecontrol { get; set; }
    public float candyspawntimer { get; set; }
    public float airspawntimer { get; set; }
    public float groundspawntimer { get; set; }
    public float speedtimer { get; set; }
    float candytime;
    float airtime;
    float groundtime;
    float timenow;
    float speedtime;
    public float beartimer { get; set; }
    public bool gamestarted { get; set; }
    bool minibearstarted;

    //TRASH


    // Use this for initialization
    void Start()
    {

        timenow = Time.time;
        beartimer = timenow + beartimer;
        gamestarted = false;
        MainControl.setStartTime(timenow);
    }

   public void startGame()
    {
        gamestarted = true;
        timenow = Time.time;
        airtime = timenow + airspawntimer;
        groundtime = timenow + groundspawntimer;
        candytime = timenow + candyspawntimer;
        speedtime = timenow + speedtimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        timenow = Time.time;
        if (gamestarted)
        {
            if (airtime <= timenow)
            {
                airtime = timenow + airspawntimer;
                firecontrol.fireAir();
            }

            if (groundtime <= timenow)
            {
                groundtime = timenow + groundspawntimer;
                firecontrol.fireGround();
            }

            if (candytime <= timenow)
            {
                candytime = timenow + candyspawntimer;
                firecontrol.fireCandy();
            }
            if (speedtime <= timenow)
            {
                speedtime = timenow + speedtimer;
                MainControl.SpeedIncrease();
            }
        }
        else {

            if (beartimer <= timenow && !minibearstarted)
            {
                
                MainControl.StartMiniBear();
                minibearstarted = !minibearstarted;
            }

        }

    }



}
