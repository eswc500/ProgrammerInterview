using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Coin_Controller : MonoBehaviour
{
    public MainPlayerData main_data;
    public float duration = 2.0f;

    [Space(10)]
    [Header("UI Elements")]   
    public TextMeshProUGUI coin_txt;

    [Space(10)]
    [Header("Audio")]
    public AudioSource audio_so;
    public AudioClip plus_clip;

    private void OnEnable()
    {
        coin_txt.text = main_data.Player_coins.Coin_qty.ToString();
    }


    public void MinusCoins(int qty)
    {
        int origin = main_data.Player_coins.Coin_qty;
        main_data.Player_coins.Coin_qty = main_data.Player_coins.Coin_qty - qty;
        ChangeCoins(origin);
    }

    public void PlusCoins(int qty)
    {
        int origin = main_data.Player_coins.Coin_qty;
        main_data.Player_coins.Coin_qty += qty;
        ChangeCoins(origin);
        PlaySound(plus_clip);
    }


    public bool NeccesaryCoins(int qty)
    {
        if(main_data.Player_coins.Coin_qty > qty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ChangeCoins(int qty)
    {
        DOTween.To(() => main_data.Player_coins.Coin_qty , x => qty = x, main_data.Player_coins.Coin_qty, duration)
            .OnUpdate(() =>
            {
                coin_txt.text = main_data.Player_coins.Coin_qty.ToString();
            });
    }

    public void PlaySound(AudioClip clip)
    {
        audio_so.PlayOneShot(clip, 0.5f);
    }

}
