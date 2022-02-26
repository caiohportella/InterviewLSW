using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon;

    int index;

    public void SetIndex(int _index)
    {
        index = _index;
    }

    //show icon on screen
    public void Set(ItemSlot _slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = _slot.item.icon;
    }

    //remove sprite and hide icon
    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
    }
}
