using UnityEngine;

public class Door : MonoBehaviour
{
    BoxCollider2D col;
    SpriteRenderer sprite;
    bool wasOpenedBefore = false;
    bool isOpen = false;
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    public void open() {
        if (!isOpen)
        {
            col.enabled = false;
            sprite.enabled = false;
            if (!wasOpenedBefore)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().MoveToNextPosition();
            }
            isOpen = true;
            wasOpenedBefore = true;
        }
        
    }

    public void close(){
        if (isOpen)
        {
            col.enabled = true;
            sprite.enabled = true;
            isOpen = false;
        }
        
    }
}
