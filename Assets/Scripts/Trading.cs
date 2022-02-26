using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trading : MonoBehaviour
{
    Store store;

    public void BeginTrading(Store _st)
    {
        _st = store;
        Debug.Log("begin trading");
    }
}
