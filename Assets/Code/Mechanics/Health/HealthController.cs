using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour {

    [SerializeField]
    private float currentHealth;
    /// <summary>
    /// The current health of this instance
    /// </summary>
    public float CurrentHealth
    {
        get { return currentHealth; }
        private set { currentHealth = value; }
    }


    /// <summary>
    /// Is the instance dead
    /// </summary>
    public bool IsDead
    {
        get
        {
            if (CurrentHealth <= 0)
                return true;
            else
                return false;
        }        
    }
    public UnityEvent onDeath;
    // Use this for initialization
    private void Start()
    {
        // TODO: Replace hard coded value with Ref to ScriptedData Object
        currentHealth = 100; 
    }

    public void TakeDamage(float damageValue)
    {
        currentHealth -= damageValue;
        if (IsDead)
        {
            onDeath.Invoke();
        }
    }
}
