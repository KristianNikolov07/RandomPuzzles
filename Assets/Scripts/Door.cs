using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    BoxCollider2D col;
    SpriteRenderer sprite;
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    public void open(){
        col.enabled = false;
        sprite.enabled = false;
    }

    public void close(){
        col.enabled = true;
        sprite.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Space)){
            open();
        }
        */
    }
}
