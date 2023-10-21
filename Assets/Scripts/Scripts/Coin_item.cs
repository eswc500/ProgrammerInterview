using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_item : MonoBehaviour
{
    public Coin_Controller coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            coin.PlusCoins(10);
            Destroy(this.gameObject);
        }
    }
}
