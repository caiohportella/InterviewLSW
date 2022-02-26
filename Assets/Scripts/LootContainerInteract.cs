using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    //Pre-written code
    [SerializeField] GameObject chestOpened;
    [SerializeField] GameObject chestClosed;
    [SerializeField] ParticleSystem coinSpawn = null;
    [SerializeField] CharacterController2D character;
    [SerializeField] bool bOpened;
    public override void Interact(Character _ch)
    {
        if(bOpened == false)
        {
            bOpened = true;
            chestClosed.SetActive(false);
            chestOpened.SetActive(true);
            coinSpawn.Play();
            character.OnGetMoney(50);
        }
    }
}
