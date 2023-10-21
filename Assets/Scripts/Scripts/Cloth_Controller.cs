using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth_Controller : MonoBehaviour
{
    /// set clothing actual
    /// 

    public MainPlayerData main_player;
    public Cloth_Anima cloth_anima_up;
    public Cloth_Anima cloth_anima_mid;
    public Cloth_Anima cloth_anima_down;


    /// set cloth ind
    /// 

    public void setUp(Cloth item)
    {
        main_player.Player_Cloth.Cloth_up = item;
        cloth_anima_up.items = main_player.Player_Cloth.Cloth_up.Cloth_anima_sprites;
        cloth_anima_up.char_sprite.sprite = main_player.Player_Cloth.Cloth_up.Cloth_anima_sprites.cloth_anima_iddle;
        cloth_anima_up.char_sprite.color = item.Cloth_anima_sprites.cloth_anima_tint;

    }

    public void Refresh()
    {
        if(cloth_anima_up.name =="")
        {
            cloth_anima_up.char_sprite.sprite = null;
        }

        if (cloth_anima_mid.name == "")
        {
            cloth_anima_mid.char_sprite.sprite = null;
        }

        if (cloth_anima_down.name == "")
        {
            cloth_anima_down.char_sprite.sprite = null;
        }

    }


    public void setMid(Cloth item)
    {
        main_player.Player_Cloth.Cloth_mid = item;
        cloth_anima_mid.items = main_player.Player_Cloth.Cloth_mid.Cloth_anima_sprites;
        cloth_anima_mid.char_sprite.sprite = main_player.Player_Cloth.Cloth_mid.Cloth_anima_sprites.cloth_anima_iddle;
        cloth_anima_mid.char_sprite.color = item.Cloth_anima_sprites.cloth_anima_tint;

    }

    public void setDown(Cloth item)
    {
        main_player.Player_Cloth.Cloth_down = item;
        cloth_anima_down.items = main_player.Player_Cloth.Cloth_down.Cloth_anima_sprites;
        cloth_anima_down.char_sprite.sprite = main_player.Player_Cloth.Cloth_down.Cloth_anima_sprites.cloth_anima_iddle;
        cloth_anima_down.char_sprite.color = item.Cloth_anima_sprites.cloth_anima_tint;

    }
}
