using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{

    public SpawnControl firecontrol;
    public BGM bgm_control;
    public SFX sfx_control;
    public MapControl mapcontrol;
    public Timer timer;
    public Rigidbody2D player;
    public Minibear minibear;
    public Bear bear;
    public Animator animator;
    public Image image;
    public float fadescreenspeed;

    public int level;
    public float minibeartime;
    public float foregroundspeed;
    public float terrainspeed;
    public float transitionspeed;
    public float drawback_force;
    public float candyspawntime;
    public float airspawntime;
    public float groundspawntime;
    public int candyspeed;
    public int candyvalue;
    public int enemyspeed;
    public int enemyvalue;
    public int life;
    public float lvlspeedup;
    public float timerspeedup;
    public float timerspeedupvalue;
    float animation_multiplier;
    
    bool gamending;
    float timestart;
    float endtime;
    static MainControl MC;

    void Awake()
    {
        timer.candyspawntimer = candyspawntime;
        timer.airspawntimer = airspawntime;
        timer.groundspawntimer = groundspawntime;
        timer.firecontrol = firecontrol;
        timer.beartimer = minibeartime;
        timer.speedtimer = timerspeedup;
        timer.gamestarted = false;
        MC = this;
    }

    void Start()
    {
        gamending = false;
        image.color = Color.Lerp(image.color, Color.clear, 1);
        bear.setBearSpeed(transitionspeed);
        firecontrol.setCandySpeed(candyspeed);
        firecontrol.setAirEnemyMoveSpeed(enemyspeed);
        firecontrol.setGroundEnemyMoveSpeed(enemyspeed);
        firecontrol.setTransitionSpeed(transitionspeed);
        mapcontrol.setTransitionSpeed(transitionspeed);
        bgm_control.setTransitionSpeed(transitionspeed);
        mapcontrol.setForegroundMoveSpeed(foregroundspeed);
        mapcontrol.setTerrainMoveSpeed(terrainspeed);
        mapcontrol.setFirstLevel(level);
        firecontrol.setFirstLevel(level);
        minibear.setMiniBearSpeed(terrainspeed);
        animation_multiplier = animator.GetFloat("speedup");

    }

    // Update is called once per frame
    void Update()
    {
        if (gamending) {
            image.color = Color.Lerp(image.color, Color.black, fadescreenspeed * Time.unscaledDeltaTime);
            if (image.color.a >= 0.95f)
            {
                
                Application.LoadLevel(2);

            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            lvlup();
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
            lvldown();

        //if (player.velocity.x == 0)
        //   player.transform.Translate(new Vector2(-1 * terrainspeed * Time.deltaTime, 0));

    }

    void checklevel()
    {
        if (life < 0)
            if (level != 2)
                lvlup();
            else
                endgame();
        else if (life > 20 && level != 0)
        {
            lvldown();

        }

    }

    void lvlup() {
        level++;
        firecontrol.setLevel(level);
        mapcontrol.setLevel(level);
        bear.setLevel(level);
        bgm_control.setTransitionState(level);
        life = 15;
        terrainspeed = terrainspeed * (1f + lvlspeedup);
        foregroundspeed = foregroundspeed * (1f + lvlspeedup);
        candyspeed = (int) (candyspeed * (1f + lvlspeedup));
        enemyspeed = (int) (enemyspeed * (1f + lvlspeedup));
        animation_multiplier = animation_multiplier + lvlspeedup;
        updateSpeed();
    }
    void lvldown() {
        level--;
        firecontrol.setLevel(level);
        mapcontrol.setLevel(level);
        bear.setLevel(level);
        bgm_control.setTransitionState(level);
        life = 15;
        terrainspeed = terrainspeed * (1f - lvlspeedup);
        foregroundspeed = foregroundspeed * (1f - lvlspeedup);
        candyspeed = (int)(candyspeed * (1f - lvlspeedup));
        enemyspeed = (int)(enemyspeed * (1f - lvlspeedup));
        animation_multiplier = animation_multiplier - lvlspeedup;
        updateSpeed();
    }
    void endgame() {
        Time.timeScale = 0f;
        gamending = true;
        endtime = Time.time - timestart;
        bgm_control.playGameOver();
        Debug.Log("game should end now...");
    }

    void updateSpeed() {
        firecontrol.setCandySpeed(candyspeed);
        firecontrol.setAirEnemyMoveSpeed(enemyspeed);
        firecontrol.setGroundEnemyMoveSpeed(enemyspeed);
        mapcontrol.setForegroundMoveSpeed(foregroundspeed);
        mapcontrol.setTerrainMoveSpeed(terrainspeed);
        animator.SetFloat("speedup",animation_multiplier);
    }


    public static void CandyHit()
    {
        MC.sfx_control.playsound((int) SFX.sfx_codes.candy);
        MC.life += MC.candyvalue;
        MC.checklevel();


    }
    public static void EnemyHit()
    {
        MC.sfx_control.playsound((int)SFX.sfx_codes.hit);
        MC.life -= MC.enemyvalue;
        MC.checklevel();
    }

    public static void StartGame()
    {

        MC.timer.startGame();
        MC.bear.setLevel(MC.level);
    }



    public static void StartMiniBear()
    {
        MC.minibear.startBear();

    }

    public static void SpeedIncrease()
    {

        MC.SpeedIncreasePriv();

    }

    public static void setStartTime(float time) {

        MC.timestart = time;
    }

    public static float getEndTime() {
        return MC.endtime;
    }
    void SpeedIncreasePriv() {

        terrainspeed = terrainspeed * (1f + timerspeedupvalue);
        foregroundspeed = foregroundspeed * (1f + timerspeedupvalue);
        candyspeed = (int)(candyspeed * (1f + timerspeedupvalue));
        enemyspeed = (int)(enemyspeed * (1f + timerspeedupvalue));
        animation_multiplier = animation_multiplier + timerspeedupvalue;

        updateSpeed();
    }


    public static void BearHit() {
        MC.endgame();
    }
    public static void land() {
        MC.sfx_control.playsound((int)SFX.sfx_codes.land);

    }
    public static void jump()
    {
        MC.sfx_control.playsound((int)SFX.sfx_codes.jump);

    }
}
