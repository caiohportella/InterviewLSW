using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interactable
{
    [SerializeField] DialogueContainer dialogue;
    public override void Interact(Character _ch)
    {
        //Debug.Log("Chatting");
        GameManager.gm.dialogueSystem.InitializeDialogue(dialogue);
    }
}
