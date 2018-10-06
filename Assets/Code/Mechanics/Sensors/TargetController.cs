using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour 
{
    #region Variable Declarations
    [SerializeField]
    private NPCController npcController;
    public NPCController NPCController
    {
        get { return npcController; }
        protected set { npcController = value; }
    }
    [SerializeField]
    private TargetSensor targetSensor;
    public TargetSensor TargetSensor
    {
        get { return targetSensor; }
        set { targetSensor = value; }
    }
    [SerializeField]
    private ActorController currentTargetable;
    public ActorController CurrentTargetable
    {
        get { return currentTargetable; }
        protected set { currentTargetable = value; }
    }

    [SerializeField]
    private List<ActorController> trackedTargets = new List<ActorController>();


    #endregion
    #region Initializations
    private void Start()
    {
        npcController = GetComponent<NPCController>();
        targetSensor = GetComponentInChildren<TargetSensor>();

        targetSensor.onValidTargetFound.AddListener(HandleValidTargetFound);
        npcController.onNPCDeath.AddListener(HandleTargetLost);
    }
    #endregion


    #region EventHandlers

    public void HandleValidTargetFound(ActorController target)
    {
        if (trackedTargets.Contains(target))
            return;

        Debug.Log(npcController.ActorName + " [TargetSensor] Found a target.");
        if (IsTargetableValid(target))
        {
            trackedTargets.Add(target);
        }          
    }

    public void HandleTargetLost(ActorController target)
    {
        trackedTargets.Remove(target);
        Debug.Log(npcController.ActorName + " [TargetSensor] Lost a target.");
    }

    #endregion

    #region Methods

    /// <summary>
    /// Clears the list of current targets and clears all events
    /// </summary>
    public void ResetTargetter()
    {
        //targetsInRange.Clear();
        //CurrentTargetable = null;

        //targetEntersRange = null;
        //targetExitsRange = null;
        //acquiredTarget = null;
        //lostTarget = null;
    }

    /// <summary>
    /// Checks if the targetable is a valid target
    /// </summary>
    /// <param name="targetable"></param>
    /// <returns>true if targetable is vaild, false if not</returns>
    private bool IsTargetableValid(ActorController target)
    {
        Debug.Log("[TargetController] Checking Target...");
        if (target == null)
        {
            return false;
        }
        string targetFaction = target.faction.FactionName;
        foreach (var enemyFaction in npcController.faction.enemies)
        {
            if (enemyFaction.FactionName.Equals(targetFaction))
            {
                Debug.Log("[TargetController] confirmed target is Hostile!");
                return true; 
            }
        }
        Debug.Log("[TargetController] target is not hostile.");
        return false;
    }
    #endregion


    private void Update()
    {

    }
}
