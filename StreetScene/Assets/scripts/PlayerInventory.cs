using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

    [SerializeField]
    private int currentKeys = 0;
    
    [SerializeField]
    private bool hasAxe = false;
    [SerializeField]
    private bool hasCrowbar = false;

    public void SetKey(bool isAdding)
    {
        if (isAdding == true)
        {
            currentKeys++;
        }
        else if (isAdding == false)
        {
            currentKeys--;
        }
    }
    public int GetKey()
    {
        return currentKeys;
    }


    public void SetAxe(bool val)
    {
        hasAxe = val;
    }
    public bool GetAxe()
    {
        return hasAxe;
    }


    public void SetCrowbar(bool val)
    {
        hasCrowbar = val;
    }
    public bool GetCrowbar()
    {
        return hasCrowbar;
    }

}
