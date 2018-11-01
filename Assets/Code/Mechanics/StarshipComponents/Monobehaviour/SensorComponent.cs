using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorComponent : StarshipComponent {

    #region Variable Declarations
    [SerializeField]
    private SensorSchematic sensorSchematic;
    public SensorSchematic SensorSchematic
    {
        get { return sensorSchematic; }
        set { sensorSchematic = value; }
    }

    [SerializeField]
    private float sensorRange;
    public float SensorRange
    {
        get { return sensorRange; }
        private set { sensorRange = value; }
    }

    [SerializeField]
    private float sensorCooldown;
    public float SensorCooldown
    {
        get { return sensorCooldown; }
        private set { sensorCooldown = value; }
    }
    [SerializeField]
    private float sensorTimer;
    public float SensorTimer
    {
        get { return sensorTimer; }
        set { sensorTimer = value; }
    }

    [SerializeField]
    private bool sensorReady;
    public bool SensorReady
    {
        get { return sensorReady; }
        set { sensorReady = value; }
    }
    [SerializeField]
    private float hP;
    public float HP
    {
        get { return hP; }
        private set { hP = value; }
    }

    [SerializeField]
    private bool operational;
    public bool Operational
    {
        get { return operational; }
        private set { operational = value; }
    }

    #endregion

    #region Init
    public void InitComponent()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = sensorSchematic.partSprite;
        SensorRange = sensorSchematic.sensorRange;
        SensorCooldown = sensorSchematic.sensorCooldown;
        SensorTimer = sensorSchematic.sensorCooldown;
        Operational = true;
    }
    #endregion

    #region Monobehaviour
    // Use this for initialization
    private void Awake()
    {

    }
    private void Start()
    {
        InitComponent();
    }
    #endregion
    public override void ApplyDamage(int amount)
    {
        hP -= amount;
    }

    public override void RepairDamage(int amount)
    {
        hP += amount;
    }
}
