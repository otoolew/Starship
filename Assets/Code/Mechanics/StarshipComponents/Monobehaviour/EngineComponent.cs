using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EngineComponent : StarshipComponent
{
    #region Properties and Variables

    [SerializeField]
    private EngineSchematic engineSchematic;
    public EngineSchematic EngineSchematic
    {
        get { return engineSchematic; }
        set { engineSchematic = value; }
    }
    [SerializeField]
    private StarshipController controller;
    public override StarshipController Controller
    {
        get { return controller; }
        set { controller = value; }
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

    [SerializeField]
    private float enginePower;
    public float EnginePower
    {
        get { return enginePower; }
        private set { enginePower = value; }
    }
    #endregion
    #region Events
    public Events.EngineDisabled onEngineDisabled;
    #endregion
    public void InitComponent()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = engineSchematic.partSprite;
        enginePower = engineSchematic.enginePower;
        operational = true;
    }
    private void Awake()
    {

    }
    private void Start()
    {
        InitComponent();
        GetComponent<Collider>().enabled = true;
    }

    public override void ApplyDamage(int amount)
    {
        HP -= amount;
        if (HP <= 0)
        {
            operational = false;
            onEngineDisabled.Invoke(this);
        }
    }

    public override void RepairDamage(int amount)
    {
        hP += amount;
    }

}
