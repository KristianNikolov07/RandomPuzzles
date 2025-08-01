using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite activateSprite;
    SpriteRenderer spriteRenderer;
    public bool isOn = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void turnOn()
    {
        isOn = true;
        Debug.Log(spriteRenderer);
        spriteRenderer.sprite = activateSprite;
    }

    public void turnOff()
    {
        isOn = false;
        spriteRenderer.sprite = defaultSprite;
    }

    public void toggle()
    {
        isOn = !isOn;

        if (isOn)
        {
            spriteRenderer.sprite = activateSprite;
        }
        else
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }
}
