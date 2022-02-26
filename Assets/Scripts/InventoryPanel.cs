using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] List<InventorySlot> slots;

    private void Start()
    {
        SetIndex();
        Display();
    }

    private void OnEnable()
    {
        Display();
    }

    private void SetIndex()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            slots[i].SetIndex(i);
        }
    }

    //set or hide icon based on inventory status
    private void Display()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                slots[i].Clean();
            }
            else
            {
                slots[i].Set(inventory.slots[i]);
            }
        }
    }

    public void AddItem(int _slot)
    {
        slots[_slot].gameObject.SetActive(true);
    }

    public void RemoveItem(int _slot)
    {
        slots[_slot].gameObject.SetActive(false);
    }

    public bool HasItem(int _slot)
    {
        return slots[_slot].gameObject.activeSelf;
    }
}
