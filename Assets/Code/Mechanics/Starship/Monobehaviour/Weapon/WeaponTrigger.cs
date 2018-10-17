using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponTrigger : MonoBehaviour 
{
    #region Variable Declarations
    public WeaponComponent parentWeapon;
    #endregion
    #region Events
    public UnityEvent onTargetEnter;
    #endregion
    #region Initializations
    // Use this for initialization
    void Start () 
	{
        parentWeapon = GetComponentInParent<WeaponComponent>();
    }
    #endregion	
	// Update is called once per frame
	void Update () 
	{
		
	}
    private void OnTriggerStay(Collider other)
    {
        try
        {
            if (parentWeapon.FactionAlignment.CanHarm(other.GetComponent<ActorController>().factionAlignment))
            {
                parentWeapon.Fire();
            }
        }
        catch (System.NullReferenceException)
        {
            Debug.Log("[WeaponTrigger] Catch");
        }

    }
    //Editor Code Here
#if UNITY_EDITOR

#endif
}
