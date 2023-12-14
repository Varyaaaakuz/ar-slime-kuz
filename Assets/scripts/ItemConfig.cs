using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    public List<Item> Items;
}