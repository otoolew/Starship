using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInventory : MonoBehaviour
{

    #region Variable Declarations
    public static ShipInventory instance;
    #endregion

    #region Initializations
    void Start()
    {
        instance = this;
    }
    #endregion

    public void StoreItem(InventoryItem ItemToStore)
    {

    }
}
