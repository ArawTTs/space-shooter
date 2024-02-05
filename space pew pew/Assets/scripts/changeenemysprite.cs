using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeenemysprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    void Start()
    {
        ChangeSprite();
    }

    // Update is called once per frame
    void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[Random.Range(0, spriteArray.Length)];
    }
}
