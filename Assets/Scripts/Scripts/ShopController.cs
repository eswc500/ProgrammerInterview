using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ShopController : MonoBehaviour
{
    [Space(10)]
    [Header("Clothes")]
    public ShopData clothes;

    [Space(10)]
    [Header("UI Elements/ But Section")]
    public GameObject main_element_section;
    public GameObject but_section_prefab;
    public TextMeshProUGUI coin_txt;

    [Space(10)]
    [Header("UI Elements/ Section")]
    public GameObject main_element_item;
    public GameObject cloth_item_prefab;
    public Animator main_ui_element;
    public GameObject shopk_ui_element;
    public TextMeshProUGUI shopk_txt;


    [Space(10)]
    [Header("Actual Data")]
    public Cloth_list_item cloth_section_actual;
    public Cloth_Controller cloth_controller;
    public Camera_Follow cam_controller;
    public Movement_Controller mov_controller;
    public MainPlayerData main_data;

    [TextArea]
    public List<string> shopk_lines;
    [TextArea]
    public string shopk_not;
    public float duration = 1f;
    public float durationtxt = 0.05f;


    [Space(10)]
    [Header("Coin")]
    public Coin_Controller coin_control;

    [Space(10)]
    [Header("Audio")]
    public AudioSource audio_so;
    public AudioClip buy_clip;
    public AudioClip notbuy_clip;
    public AudioClip swap_clip;
    public AudioClip equip_clip;
    public AudioClip open_clip;




    private void OnEnable()
    {
        SetClothSections();
        SuitUp();
    }

    // actual clothes
    public void SuitUp()
    {
        if(main_data.Player_Cloth.Cloth_up.Cloth_name != "" )
        {
            EquipItem("Up", main_data.Player_Cloth.Cloth_up, false);
        }

        if (main_data.Player_Cloth.Cloth_mid.Cloth_name != "")
        {
            EquipItem("Mid", main_data.Player_Cloth.Cloth_mid, false);
        }

        if (main_data.Player_Cloth.Cloth_down.Cloth_name != "")
        {
            EquipItem("Down", main_data.Player_Cloth.Cloth_down, false);
        }
    }


    /// set section buttons
    public void SetClothSections()
    {
        for (int i = 0; i < clothes.Data_Cloth1.Cloth_section.Count; i++)
        {
            GameObject section_itemg = Instantiate(but_section_prefab, main_element_section.transform);

            Section_Button section_itemg2 = section_itemg.GetComponent<Section_Button>();
            section_itemg2.section_item_main = clothes.Data_Cloth1.Cloth_section[i];
            section_itemg2.Set_Item();
        }
    }


    /// set items section
    public void SetClothItems()
    {
        for (int a = 0; a < main_element_item.transform.childCount; a++)
        {
            Destroy(main_element_item.transform.GetChild(a).gameObject);
        }

        for (int i = 0; i < cloth_section_actual.Cloth_section_items.Count; i++)
        {
            GameObject cloth_itemg = Instantiate(cloth_item_prefab, main_element_item.transform);
            Cloth_Item cloth_itemg2 = cloth_itemg.GetComponent<Cloth_Item>();
            cloth_itemg2.cloth_item_main = cloth_section_actual.Cloth_section_items[i];
            cloth_itemg2.Set_Item();
        }        
    }

    /// change section
    public void SwapItem(Cloth_list_item section)
    {
        cloth_section_actual = section;
        SetClothItems();
    }


    /// select
    /// is bought?
    /// buy

    public void SelectItem(Cloth cloth_item_go)
    {        
        for (int i = 0; i < cloth_section_actual.Cloth_section_items.Count; i++)
        {
            // search item
            if(cloth_section_actual.Cloth_section_items[i].Cloth_name == cloth_item_go.Cloth_name )
            {
                //is it bought?
                if(cloth_section_actual.Cloth_section_items[i].isBought is false)
                {
                    // needed coins
                    if(coin_control.NeccesaryCoins(cloth_section_actual.Cloth_section_items[i].Cloth_price) is true)
                    {
                        // if not bought, set bought and refresh ui
                        coin_control.MinusCoins(cloth_section_actual.Cloth_section_items[i].Cloth_price);
                        Debug.Log("coins " + coin_control.main_data.Player_coins.Coin_qty + " minus " + cloth_section_actual.Cloth_section_items[i].Cloth_price);
                        cloth_section_actual.Cloth_section_items[i].isBought = true;
                        Refresh_items();
                        PlaySound(buy_clip);
                    }
                    else
                    {
                        Debug.Log("Not enough coins");
                        ShopKOpen(false);
                        PlaySound(notbuy_clip);

                    }

                } 
                else
                {
                    coin_control.PlusCoins(cloth_section_actual.Cloth_section_items[i].Cloth_price);
                    cloth_section_actual.Cloth_section_items[i].isBought = false;
                    Refresh_items();

                    if(main_data.Player_Cloth.Cloth_up.Cloth_name == cloth_item_go.Cloth_name)
                    {
                        main_data.Player_Cloth.Cloth_up = null;
                        cloth_controller.setUp(cloth_item_go);

                    }
                    else if(main_data.Player_Cloth.Cloth_mid.Cloth_name == cloth_item_go.Cloth_name)
                    {
                        main_data.Player_Cloth.Cloth_mid = null;

                    }
                    else if (main_data.Player_Cloth.Cloth_down.Cloth_name == cloth_item_go.Cloth_name)
                    {
                        main_data.Player_Cloth.Cloth_down = null;

                    }

                }

            }
        }
        
    }

    public void Refresh_items()
    {
        for (int a = 0; a < main_element_item.transform.childCount; a++)
        {
            main_element_item.transform.GetChild(a).GetComponent<Cloth_Item>().Refresh();
        }
    }
 

    /// equip
    ///
    
    public void EquipItem(string section, Cloth cloth_item_go, bool ShopKeep)
    {
        PlaySound(equip_clip);

        if (section=="Up")
        {
            cloth_controller.setUp(cloth_item_go);
        }
        else if(section == "Mid")
        {
            cloth_controller.setMid(cloth_item_go);

        }
        else if(section == "Down")
        {
            cloth_controller.setDown(cloth_item_go);

        }

        if(ShopKeep is true)
        {
            ShopKOpen(true);

        }
       
    }


    public void QuitUI()
    {
        main_ui_element.SetTrigger("back");
        cam_controller.exitShop();
        mov_controller.enabled = true;

        StopAnima(mov_controller.char_anima_main, true);
        ShopKClose();

        if (mov_controller.char_anima_up)
        {
            mov_controller.char_anima_up.enabled = true;
            StopAnima(mov_controller.char_anima_up, true);

        }

        if (mov_controller.char_anima_mid)
        {
            mov_controller.char_anima_mid.enabled = true;
            StopAnima(mov_controller.char_anima_mid, true);
        }

        if (mov_controller.char_anima_down)
        {
            mov_controller.char_anima_down.enabled = true;
            StopAnima(mov_controller.char_anima_down, true);

        }

    }

    public void OpenUI()
    {
        main_ui_element.SetTrigger("go");
        cam_controller.setShop();
        PlaySound(open_clip);
        StopAnima(mov_controller.char_anima_main, false);


        if(mov_controller.char_anima_up)
        {
            StopAnima(mov_controller.char_anima_up, false);

        }

        if (mov_controller.char_anima_mid)
        {
            StopAnima(mov_controller.char_anima_mid, false);
        }

        if (mov_controller.char_anima_down)
        {
            StopAnima(mov_controller.char_anima_down, false);

        }

        mov_controller.enabled = false;

    }

    public void StopAnima(Animator anima, bool check)
    {
        if(check is false)
        {
            anima.speed = 0f;
            anima.SetFloat("Speed", 0f);
        }
        else
        {
            anima.speed = 1f;
        }
        
    }

    public void ShopKOpen(bool check)
    {
        RectTransform rect = shopk_ui_element.GetComponent<RectTransform>();
        int rand = Random.Range(0, shopk_lines.Count);
        string line = shopk_lines[rand];

        rect.DOScale(new Vector3(1,1,1), duration)
            .SetEase(Ease.OutBounce) // Cambia el Ease según tus preferencias
            .OnComplete(() =>
            {
                if(check is true)
                {
                    ShopKDialogue(line);

                }
                else
                {
                    ShopKDialogue(shopk_not);

                }
            });
    }

    public void ShopKDialogue(string line)
    {
        shopk_txt.text = "";

        DOTween.To(() => shopk_txt.text, x => shopk_txt.text = x, line, line.Length * durationtxt)
            .SetOptions(true)
            .SetDelay(0.5f);
    }

    public void ShopKClose()
    {
        RectTransform rect = shopk_ui_element.GetComponent<RectTransform>();

        rect.DOScale(Vector3.zero, duration)
            .SetEase(Ease.OutBounce);
    }

    public void PlaySound(AudioClip clip)
    {
        audio_so.PlayOneShot(clip, 0.5f);
    }
}
