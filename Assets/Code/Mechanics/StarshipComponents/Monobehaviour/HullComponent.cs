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
    private void Start()
    {
        InitComponent();
    }
    public void InitComponent()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = hullSchematic.partSprite;
        hP = hullSchematic.HP;

        operational = true;
    }

    public override void ApplyDamage(int amount)
    {
        Debug.Log(gameObject.name+" Hit");
        HP -= amount;
    }

    public override void RepairDamage(int amount)
    {
        hP += amount;
    }
}
