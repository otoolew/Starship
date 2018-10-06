using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSensor : MonoBehaviour
{
    #region Variable Declarations
    [SerializeField]
    private TargetController targetController;
    public TargetController TargetController
    {
        get { return targetController; }
        protected set { targetController = value; }
    }
    [SerializeField]
    private float sensorRange;
    public float SensorRange
    {
        get { return sensorRange; }
        set { sensorRange = value; }
    }
    [SerializeField]
    private FactionAlignment factionAlignment;
    public FactionAlignment FactionAlignment
    {
        get { return factionAlignment; }
        protected set { factionAlignment = value; }
    }
    [SerializeField]
    private List<Faction> enemyFactions = new List<Faction>();
    public List<Faction> EnemyFactions
    {
        get { return enemyFactions; }
        protected set { enemyFactions = value; }
    }
    #endregion
    #region Events
    public Events.EventValidTargetScan onValidTargetFound;

    #endregion
    #region Initializations
    private void Start()
    {
        targetController = GetComponentInParent<TargetController>();
        enemyFactions = GetComponentInParent<NPCController>().faction.enemies;
        //enemyFactions = factionAlignment.faction.enemies;
    }
    #endregion
    #region Methods
    /// <summary>
    /// On entering the trigger, a valid targetable is added to the tracking list.
    /// </summary>
    /// <param name="other">The other collider in the collision</param>
    private void OnTriggerEnter(Collider other)
    {   
        try
        {
            ActorController target = other.gameObject.GetComponent<ActorController>();
            onValidTargetFound.Invoke(target);
        }
        catch (NullReferenceException)
        {
            Debug.Log(other.gameObject + " has no ActorController");
            return;
        }
    }

    #endregion
}
