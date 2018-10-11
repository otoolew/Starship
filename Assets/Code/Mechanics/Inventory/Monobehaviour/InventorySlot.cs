using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour 
{
    #region Variable Declarations
    public ItemConfig itemConfig;
    public Image image;
    public Text amountText;
    public int ItemAmount;
    public bool isEmpty;
    public UnityEvent onValueChange;
    #endregion
    #region Initializations
    // Use this for initialization
    void Start () 
	{
        image.sprite = itemConfig.itemIcon;
    }
    #endregion	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void UpdateUI()
    {
        amountText.text = ItemAmount.ToString();
    }
	//Editor Code Here
	#if UNITY_EDITOR

    #endif
}
