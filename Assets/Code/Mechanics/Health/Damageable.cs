using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Damageable : MonoBehaviour
{
    #region Variable Declarations

    [SerializeField]
    private HealthController healthController;
    public HealthController HealthController
    {
        get { return healthController; }
        private set { healthController = value; }
    }
    [SerializeField]
    private Collider damageableCollider;
    public Collider DamageableCollider
    {
        get { return damageableCollider; }
        protected set { damageableCollider = value; }
    }
    #endregion
    #region Initializations
    // Use this for initialization
    void Start () 
	{
        healthController = GetComponentInParent<HealthController>();
        damageableCollider = GetComponent<Collider>();
    }
    #endregion

        
    // Update is called once per frame
    void Update () 
	{
		
	}
	
	//Editor Code Here
	#if UNITY_EDITOR

    #endif
}
