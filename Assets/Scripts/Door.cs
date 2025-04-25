using UnityEngine;

public class Door : MonoBehaviour
{
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
}
