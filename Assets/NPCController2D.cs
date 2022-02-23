using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController2D : Interactable
{
    [SerializeField] DialogueContainer dialogue;
    Button button;
    Character character;
    Trading trading;
    Store store;

    public override void Interact(Character _ch)
    {
        GameManager.gm.dialogueSystem.InitializeDialogue(dialogue);
        trading = _ch.GetComponent<Trading>();

        if (trading == null) return;

        trading.BeginTrading(store);
    }
}
