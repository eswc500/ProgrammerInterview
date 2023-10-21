using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Section_Button : MonoBehaviour
{
    [Space(10)]
    [Header("Section Info")]
    public Cloth_list_item section_item_main;
    private ShopController shop_item;


    [Space(10)]
    [Header("Section UI")]
    public Image section_cloth_img;
    public Button section_cloth_but;

    private void OnEnable()
    {
        shop_item = GameObject.FindGameObjectWithTag("Shop").GetComponent<ShopController>();

        section_cloth_but = this.GetComponent<Button>();
        section_cloth_but.onClick.AddListener(Send_Item);
    }

    public void Send_Item()
    {
        shop_item.SwapItem(section_item_main);
    }

    public void Set_Item()
    {
        section_cloth_img.sprite = section_item_main.Cloth_section_icon;        
    }
}
