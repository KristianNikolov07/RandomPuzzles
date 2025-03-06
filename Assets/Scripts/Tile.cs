using System;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite defaultSprite;
    public Sprite greenSprite;
    public Sprite redSprite;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        spriteRenderer.sprite = greenSprite;
        Debug.Log("a");
    }

        void OnTriggerExit2D(Collider2D col){
        spriteRenderer.sprite = defaultSprite;
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
