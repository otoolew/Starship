using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour 
{
    #region Variable Declarations
    public Enums.WayPointType wayPointType;
    public WayPoint nextWayPoint;
	#endregion
	#region Initializations
	// Use this for initialization
	void Start () 
	{
		
	}
    #endregion	
	// Update is called once per frame
	void Update () 
	{
		
	}
    private void OnTriggerEnter(Collider other)
    {
        
    }
    //Editor Code Here
#if UNITY_EDITOR

#endif
}
