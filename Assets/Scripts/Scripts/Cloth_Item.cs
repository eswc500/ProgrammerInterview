using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cloth_Item : MonoBehaviour
{
    [Space(10)]
    [Header("Cloth Info")]
    public Cloth cloth_item_main;
    private ShopController shop_item;

    [Space(10)]
    [Header("Cloth Item UI")]
    public Image cloth_item_img;
    public TextMeshProUGUI cloth_item_price;
    public TextMeshProUGUI cloth_item_name;
    public Button but_item;
    public Button equip_item;
    public Button sell_item;
    public GameObject price_obj;
    public GameObject equip_obj;

    private void OnEnable()
    {   
        shop_item = GameObject.FindGameObjectWithTag("Shop").GetComponent<ShopController>();
        but_item.onClick.AddListener(Send_Item);
        sell_item.onClick.AddListener(Send_Item);
        equip_item.onClick.AddListener(Equip_item);
    }

    public void Send_Item()
    {
        if(shop_item)
        {
            shop_item.SelectItem(cloth_item_main);
        }
    }

    public void Set_Item()
    {
        if(cloth_item_main !=null)
        {
            cloth_item_img.sprite = cloth_item_main.Cloth_icon;
            cloth_item_name.text = cloth_item_main.Cloth_name;
            BoughtActive(cloth_item_main.isBought);
            
        }
    }

    public void Equip_item()
    {
        shop_item.EquipItem(shop_item.cloth_section_actual.Cloth_section_name, cloth_item_main, true);
    }

    public void Refresh()
    {
        BoughtActive(cloth_item_main.isBought);
    }

    public void BoughtActive(bool check)
    {
        if(check is true)
        {
            price_obj.SetActive(false);
            equip_obj.SetActive(true);
        }
        else
        {            
            price_obj.SetActive(true);
            cloth_item_price.text = cloth_item_main.Cloth_price.ToString();
            equip_obj.SetActive(false);
        }
    }


}
