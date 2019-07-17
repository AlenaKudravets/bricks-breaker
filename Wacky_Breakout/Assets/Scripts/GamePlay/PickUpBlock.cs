using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBlock : Block
{
    [SerializeField]
    private Sprite freezerBlockSprite;

    [SerializeField]
    private Sprite speedUpBlockSprite;

    //private SpriteRenderer spriteRenderer;


    void Start()
    {
        //SetupSprite(effect);
        blockPoint = ConfigurationUtils.PickUpBlockPoint;       
    }

    public void SetupSprite(PickupEffect effect)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (effect == PickupEffect.Freezer)
        {
            spriteRenderer.sprite = freezerBlockSprite;
        }
        else if (effect == PickupEffect.Speedup)
        {
            spriteRenderer.sprite = speedUpBlockSprite;
        }
    }
}
