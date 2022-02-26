using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Item/Item")]
public class Item : ScriptableObject
{
    public int price;
    public string Name;
    public bool bCanBeSold = true;
    public Sprite icon;

}
