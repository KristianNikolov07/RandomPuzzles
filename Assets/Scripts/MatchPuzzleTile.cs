using UnityEngine;

public class MatchPuzzleTile : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public bool activated = false;
    public Sprite activatedSprite;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        if(activated == false){
            spriteRenderer.sprite = activatedSprite;
            GetComponentInParent<MatchPuzzle>().TileClicked(activatedSprite);
        }
        activated = true;
    }
}
