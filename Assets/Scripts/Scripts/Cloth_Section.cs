using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Cloth Section", menuName = "Custom/Cloth Section")]
public class Cloth_Section : ScriptableObject
{
    public List<Cloth_list_item> Cloth_section;
}

[System.Serializable]
public class Cloth_list_item
{
    public string Cloth_section_name;
    public Sprite Cloth_section_icon;
    public List<Cloth> Cloth_section_items;
}


[System.Serializable]
public class Cloth
{
    public string Cloth_name;
    public int Cloth_price;
    public Sprite Cloth_icon;
    public cloth_anima_item Cloth_anima_sprites;
    public bool isBought;
}
