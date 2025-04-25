using UnityEngine;
using UnityEngine.UI;

public class LightsOutLight : MonoBehaviour
{
    public int index;
    public bool isOn = false;
    public Sprite offSprite;
    public Sprite onSprite;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown(){
        GetComponentInParent<LightsOut>().LightClicked(index);
    }

    public void Toggle(){
        isOn = !isOn;
        if(isOn){
            spriteRenderer.sprite = onSprite;
        }
        else{
            spriteRenderer.sprite = offSprite;
        }
    }
}
