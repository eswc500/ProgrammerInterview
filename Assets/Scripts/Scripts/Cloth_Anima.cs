using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cloth_anima_item
{
    public Color cloth_anima_tint;
    public Sprite cloth_anima_iddle;
    public List<Sprite> cloth_anima_sprites_down;
    public List<Sprite> cloth_anima_sprites_up;
    public List<Sprite> cloth_anima_sprites_right;
}


public class Cloth_Anima : MonoBehaviour
{
    public cloth_anima_item items;
    public SpriteRenderer char_sprite;



    public void Iddle()
    {
        if (items != null)
        {
            char_sprite.sprite = items.cloth_anima_iddle;

        }
        else
        {
            char_sprite.sprite = null;

        }
    }

    public void WalkDown(int sprite_id)
    {
        if(items!=null)
        char_sprite.sprite = items.cloth_anima_sprites_down[sprite_id];
    }

    public void WalkUp(int sprite_id)
    {
        if (items != null)
        char_sprite.sprite = items.cloth_anima_sprites_up[sprite_id];
    }

    public void WalkRight(int sprite_id)
    {
        if (items != null)
        char_sprite.sprite = items.cloth_anima_sprites_right[sprite_id];
    }

}
