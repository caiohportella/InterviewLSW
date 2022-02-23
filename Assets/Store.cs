using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Interactable
{
    public override void Interact(Character _ch)
    {
        Trading trading = _ch.GetComponent<Trading>();

        if (trading == null) return;

        trading.BeginTrading(this);
    }
}
