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
    private ActorController currentTarget;
    public ActorController CurrentTarget
    {
        get { return currentTarget; }
        protected set { currentTarget = value; }
    }

    [SerializeField]
    private List<ActorController> trackedTargets = new List<ActorController>();
    #region Actions / Events
    public Events.AcquiredTarget onAcquiredTarget;
    public bool HasValidTarget;
    #endregion

    #endregion
    #region Initializations
    private void Start()
    {
        npcController = GetComponent<NPCController>();
        targetSensor = GetComponentInChildren<TargetSensor>();

        targetSensor.onValidTargetFound.AddListener(HandleValidTargetFound);
        //npcController.onTargetDeath.AddListener(HandleTargetLost);
    }
    #endregion


    #region EventHandlers

    public void HandleValidTargetFound(ActorController target)
    {
        if (trackedTargets.Contains(target))
            return;       
        if (IsTargetableValid(target))
        {
            trackedTargets.Add(target);
            target.onTargetDeath.AddListener(HandleTargetLost);
            Debug.Log(npcController.ActorName + " [TargetSensor] Found a target.");
            HasValidTarget = HasTarget();
        }          
    }

    public void HandleTargetLost(ActorController target)
    {
        trackedTargets.Remove(target);        
        Debug.Log(npcController.ActorName + " [TargetSensor] Lost a target.");
        HasValidTarget = HasTarget();
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
        Debug.Log("[TargetController] target is not hostile.");
        return npcController.factionAlignment.CanHarm(target.factionAlignment);
    }
    public bool HasTarget()
    {
        if (trackedTargets.Count < 1)
            return false;


        CurrentTarget = trackedTargets[0];
        if (CurrentTarget != null)
        {
            onAcquiredTarget.Invoke(CurrentTarget);
            return true;
        }
            
        return false;
    }

    #endregion

    private void Update()
    {

    }
}
