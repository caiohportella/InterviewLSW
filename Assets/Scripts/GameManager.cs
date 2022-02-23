using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public void Awake()
    {
        //instanciating the Game Manager
        gm = this;
    }

    public GameObject player;
    public ItemContainer inventoryContainer;
    public DialogueSystem dialogueSystem;
}
