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

    void OnMouseDown()
    {
        if (!activated)
        {
            spriteRenderer.sprite = activatedSprite;
            GetComponentInParent<MatchPuzzle>().TileClicked(activatedSprite);
        }
        activated = true;
    }
}
