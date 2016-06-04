using UnityEngine;
using System.Collections;

public class Minibear : MonoBehaviour
{

    public Sprite happy;
    public Sprite sad;
    SpriteRenderer sprite;
    float speed;
    bool bearstarted;
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

    }
    // Use this for initialization
    void Start()
    {
        sprite.sprite = happy;

    }

    // Update is called once per frame
    void Update()
    {

        if(bearstarted)
        transform.Translate(new Vector2(-1 * speed * Time.deltaTime, 0));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MapEdges"))
        {
            MainControl.StartGame();
            gameObject.SetActive(false);
        }
        else {
            sprite.sprite = sad;

        }

    }

    public void startBear() {
        bearstarted = true;
    }

    public void setMiniBearSpeed(float speed) {
        this.speed = speed;
    }
}
