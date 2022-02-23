using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemSlot
{
    public Item item;
    public int count;
}

[CreateAssetMenu(menuName ="Data/Item/ItemContainer")]
public class ItemContainer : ScriptableObject
{
    //stores slots quantity
    public List<ItemSlot> slots;

    //adding items to inventory
    public void Add(Item _item, int _count)
    {
        _count = 1;

        if(_item != null)
        {
            //find empty spot and add item
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            itemSlot.item = _item;
        }
    }
}
