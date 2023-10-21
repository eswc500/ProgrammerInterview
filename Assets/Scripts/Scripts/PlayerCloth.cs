using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Player Cloth", menuName = "Custom/Player Cloth")]
public class PlayerCloth : ScriptableObject
{
    [Header("Cloth Up")]
    public Cloth Cloth_up;

    [Space(10)]
    [Header("Cloth Mid")]
    public Cloth Cloth_mid;

    [Space(10)]
    [Header("Cloth Down")]
    public Cloth Cloth_down;
}