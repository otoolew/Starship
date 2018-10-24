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
        private set { npcController = value; }
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
        targetSensor.FactionAlignment = npcController.factionAlignment;

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
    /// Checks if the targetable is a valid target
    /// </summary>
    /// <param name="targetable"></param>
    /// <returns>true if targetable is vaild, false if not</returns>
    private bool IsTargetableValid(ActorController target)
    {
        Debug.Log(npcController.ActorName + "[TargetController] Checking Target...");
        if (target == null)
        {
            return false;
        }
        Debug.Log(npcController.ActorName + "[TargetController] target is not hostile.");
        return npcController.factionAlignment.CanHarm(target.factionAlignment);
    }

    public bool HasTarget()
    {
        if (trackedTargets.Count < 1)
            return false;
        SortTargetListByDistance();

        CurrentTarget = trackedTargets[0];
        if (CurrentTarget != null)
        {
            onAcquiredTarget.Invoke(CurrentTarget);
            return true;
        }
            
        return false;
    }
    public void SortTargetListByDistance()
    {
        trackedTargets.Sort(delegate (ActorController a, ActorController b)
        {
            return Vector2.Distance(transform.position, a.transform.position)
            .CompareTo(Vector2.Distance(transform.position, b.transform.position));
        });
    }
    public float DistanceToTarget()
    {
        return Vector3.Distance(gameObject.transform.position, CurrentTarget.transform.position);
    }

    #endregion

    private void Update()
    {

    }
}
