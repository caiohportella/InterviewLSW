using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    //Pre-written code
    [SerializeField] GameObject chestOpened;
    [SerializeField] GameObject chestClosed;
    [SerializeField] bool opened;
    public override void Interact(Character _ch)
    {
        if(opened == false)
        {
            opened = true;
            chestClosed.SetActive(false);
            chestOpened.SetActive(true);
        }
    }
}
