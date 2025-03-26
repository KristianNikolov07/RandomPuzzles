using UnityEngine;
using UnityEngine.UI;

public class LightsOutLight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int index;
    public bool isOn = false;
    public Sprite offSprite;
    public Sprite onSprite;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
