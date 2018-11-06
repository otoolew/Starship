using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class HullComponent : StarshipComponent
{
    [SerializeField]
    private HullSchematic hullSchematic;
    public HullSchematic HullSchematic
    {
        get { return hullSchematic; }
        set { hullSchematic = value; }
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

    #region Events
    public Events.HullDisabled onHullDisabled;
    #endregion


    private void Start()
    {
        InitComponent();
        GetComponent<Collider>().enabled = true;
    }
    public void InitComponent()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = hullSchematic.partSprite;
        hP = hullSchematic.HP;

        operational = true;
    }

    public override void ApplyDamage(int amount)
    {
        Debug.Log(controller + "'s " + gameObject.name + " Hit");
        hP -= amount;
        if (hP <= 0)
        {
            operational = false;
            onHullDisabled.Invoke(this);
        }
    }

    public override void RepairDamage(int amount)
    {
        hP += amount;
    }
}
