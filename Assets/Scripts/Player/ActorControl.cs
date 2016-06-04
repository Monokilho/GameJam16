using UnityEngine;
using System.Collections;

public class ActorControl : MonoBehaviour
{

    float land;
    public float maxjump;
    public float speed;
    public float jumpforce;

    public Rigidbody2D body;
    public Animator animator;
    SpriteRenderer spriterenderer;
    public bool canmove;
    public bool canmovevertical;
    public bool canmovehorizontal;
    public bool canaction;
    public float maxspeed;
    bool right = true;
    bool beenhit;
    int framecount;
    int blinkcount;
    void Start()
    {
        beenhit = false;
        spriterenderer = GetComponent<SpriteRenderer>();
        canaction = true;
        land = transform.position.y;
    }

    void Update()
    {

        if (beenhit)
            blink();
        if (canmove)
        {
            movement();

        }
        if (canaction)
        {
            action();
        }
        float temp;
        temp = (transform.position.y - (-130)) * 0.5f;
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, temp+130, -10);
    }


    void blink() {
        framecount++;
        if (framecount == 5)
        {
            spriterenderer.enabled = !spriterenderer.enabled;
            framecount = 0;
            blinkcount++;
            if (blinkcount == 6)
                beenhit = false;
        }
    }

    void Hit() {
        spriterenderer.enabled = !spriterenderer.enabled;
        beenhit = true;
        framecount = 0;
        blinkcount = 1;
    }

    void flip()
    {
        right = !right;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    void action()
    {



        if (Input.GetButtonDown("Action"))
        {
            animator.SetBool("jump", true);
            MainControl.jump();
            land = transform.position.y;
            body.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }
        float jump = Mathf.Abs(transform.position.y - land);
        if (Input.GetButton("Action") && jump < maxjump)
        {
            body.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }

        if ((Input.GetButtonUp("Action") || (Input.GetButton("Action") && jump >= maxjump)))
        {
            
            canaction = false;
        }

    }




    void movement()
    {

        //horizontal movement
        float moveX = 0f;
        if (canmovehorizontal)
        {
            moveX = Input.GetAxis("Horizontal") * speed;
            if (moveX >= 0 && right == false)
            {
                flip();

            }
            else if (moveX < 0 && right == true)
            {
                flip();
            }
            if (moveX != 0)
            {
               animator.SetBool("moving", true);
            }
            else{
                animator.SetBool("moving", false);
            }
        }

       
        body.AddForce(new Vector2(moveX, 0));
       float x = body.velocity.x;
        x = Mathf.Clamp(x, -1 * maxspeed, maxspeed);
      body.velocity = new Vector2(x, body.velocity.y);
       
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == 10 && !canaction)
        {
            animator.SetBool("jump", false);
            canaction = true;
            MainControl.land();
        }
    }

}
