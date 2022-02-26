using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    public CharacterController2D character;
    
    public void OnBuy()
    {
        character.OnBuy();
    }

    public void OnSell()
    {
        character.OnSell();
    }
}
