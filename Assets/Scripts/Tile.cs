using System;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int id;
    public Sprite defaultSprite;
    public Sprite greenSprite;
    public Sprite redSprite;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col){
        GetComponentInParent<TilesPuzzle>().tileActivated(id);
        changeToGreen();
    }

        void OnTriggerExit2D(Collider2D col){
        changeToDefault();
    }

    public void changeToGreen(){
        spriteRenderer.sprite = greenSprite;
    }

    public void changeToDefault(){
        spriteRenderer.sprite = defaultSprite;
    }

    public void changeToRed(){
        spriteRenderer.sprite = redSprite;
    }

}
