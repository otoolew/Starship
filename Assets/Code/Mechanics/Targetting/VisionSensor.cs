using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisionSensor : MonoBehaviour
{
    public NPCController controller;
    #region Fields / Properties
    public float timer;
    RaycastHit rayHit;
    public bool HasTarget;


    [SerializeField]
    private float sensorRange;
    public float SensorRange
    {
        get { return sensorRange; }
        set { sensorRange = value; }
    }

    [SerializeField]
    private float viewRadius;
    public float ViewRadius
    {
        get { return viewRadius; }
        set { viewRadius = value; }
    }

    [SerializeField]
    private float detectionRate;
    public float DetectionRate
    {
        get { return detectionRate; }
        set { detectionRate = value; }
    }

    public LayerMask targetLayer;

    [SerializeField]
    private string[] detectionTags;
    public string[] DetectionTags
    {
        get { return detectionTags; }
        set { detectionTags = value; }
    }

    [SerializeField]
    private List<ActorController> targetList;
    public List<ActorController> TargetList
    {
        get { return targetList; }
        set { targetList = value; }
    }

    [SerializeField]
    private Transform currentTarget;
    public Transform CurrentTarget
    {
        get { return currentTarget; }
        set { currentTarget = value; }
    }

    #endregion
    #region Events
    public UnityEvent onGainSight;
    public UnityEvent onLoseSight;

    #endregion

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<NPCController>();
        //DetectionTags = controller.EnemyTags;
        targetList = new List<ActorController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        HasTarget = TargetInSight();
        if (timer >= detectionRate)
        {
            timer = 0f;
            HasTarget = TargetInSight();

        }
        if (HasTarget)
        {
            onGainSight.Invoke();
        }
        else
        {
            onLoseSight.Invoke();
        }

    }
    private void RefreshTargetList()
    {
        string hitTag = "";
        Collider[] targetsInView = Physics.OverlapSphere(transform.position, viewRadius, targetLayer);
        foreach (var scannedTarget in targetsInView)
        {
            //hitTag = scannedTarget.gameObject.GetComponent<ActorController>().TeamTag;

            foreach (var tag in DetectionTags)
            {
                if (tag.Equals(hitTag))
                {
                    currentTarget = scannedTarget.transform;
                    controller.ShipController.targetDestination = currentTarget;

                }
            }
        }
        currentTarget = null;
    }
    private bool TargetInSight()
    {
        string hitTag = "";
        Collider[] targetsInView = Physics.OverlapSphere(transform.position, viewRadius, targetLayer);
        foreach (var scannedTarget in targetsInView)
        {
            //hitTag = scannedTarget.gameObject.GetComponent<ActorController>().faction;

            foreach (var tag in DetectionTags)
            {
                if (tag.Equals(hitTag))
                {
                    currentTarget = scannedTarget.transform;
                    controller.ShipController.targetDestination = currentTarget;
                    return true;
                }
            }
        }
        currentTarget = null;
        return false;
    }
}
