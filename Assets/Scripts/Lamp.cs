using UnityEngine;

public class Lamp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite defaultSprite;
    public Sprite activateSprite;
    SpriteRenderer spriteRenderer;
    bool isOn = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOn(){
        isOn = true;
        spriteRenderer.sprite = activateSprite;
    }

    public void turnOff(){
        isOn = false;
        spriteRenderer.sprite = defaultSprite;
    }

    public void toggle(){
        isOn = !isOn;

        if (isOn){
            spriteRenderer.sprite = activateSprite;
        }
        else{
            spriteRenderer.sprite = defaultSprite;
        }
    }
}
