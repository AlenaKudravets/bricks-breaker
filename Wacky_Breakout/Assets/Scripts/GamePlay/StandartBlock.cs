using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBlock : Block
{
    [SerializeField]
    private Sprite[] standartBlockSprites;

    private int spriteNum;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChooseSprite();
        blockPoint = ConfigurationUtils.StandartBlockPoint;
    }

    void Update()
    {
        
    }

    private void ChooseSprite()
    {
        spriteNum = Random.Range(1, 4);
        if(spriteNum == 1)
        {
            spriteRenderer.sprite = standartBlockSprites[0];
        }
        else if(spriteNum == 2)
        {
            spriteRenderer.sprite = standartBlockSprites[1];
        }
        else
        {
            spriteRenderer.sprite = standartBlockSprites[2];
        }
    }
}
