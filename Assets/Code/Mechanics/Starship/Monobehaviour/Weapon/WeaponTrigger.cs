using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponTrigger : MonoBehaviour 
{
    #region Variable Declarations
    public WeaponComponent parentWeapon;
    public TargetController targetController;
    #endregion
    #region Events

    #endregion
    #region Initializations
    // Use this for initialization
    void Start () 
	{
        parentWeapon = GetComponentInParent<WeaponComponent>();
        targetController = parentWeapon.GetComponentInParent<TargetController>();
    }
    #endregion	
	// Update is called once per frame
	void Update () 
	{
        if (targetController.CurrentTarget != null)
        {
            if(targetController.DistanceToTarget() < parentWeapon.WeaponRange)
            {
                parentWeapon.Fire();
            }
     
        }
	}

    //Editor Code Here
#if UNITY_EDITOR

#endif
}
