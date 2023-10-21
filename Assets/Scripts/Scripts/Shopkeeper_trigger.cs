using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper_trigger : MonoBehaviour
{
    public bool UI_active = false;
    public ShopController shop_controller;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if (UI_active is false)
            {
                UI_active = true;
                shop_controller.OpenUI();
            }
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UI_active = false;
        }
    }


}
