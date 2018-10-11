using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryEventTrigger : EventTrigger
{
    #region Variable Declarations
    GameObject currentTarget;
	#endregion
	#region Initializations
	// Use this for initialization
	void Start () 
	{
		
	}
    #endregion	
    public override void OnDrag(PointerEventData data)
    {
        Debug.Log("OnDrag called. " + data.pointerPress);
    }

    public override void OnDrop(PointerEventData data)
    {
        Debug.Log("OnDrag called. " + data.pointerPress);
    }

    //Editor Code Here
#if UNITY_EDITOR

#endif
}
