using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EngineComponent : MonoBehaviour
{
    [SerializeField]
    private EngineSchematic engineSchematic;
    public EngineSchematic EngineSchematic
    {
        get { return engineSchematic; }
        set { engineSchematic = value; }
    }

    [SerializeField]
    private float durability;
    public float Durability
    {
        get { return durability; }
        private set { durability = value; }
    }
    [SerializeField]
    private float componentDrag;
    public float ComponentDrag
    {
        get { return componentDrag; }
        private set { componentDrag = value; }
    }
    [SerializeField]
    private bool operational;
    public bool Operational
    {
        get { return operational; }
        private set { operational = value; }
    }
    [SerializeField]
    private float thrustPower;
    public float ThrustPower
    {
        get { return thrustPower; }
        private set { thrustPower = value; }
    }
    public void InitComponent()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = engineSchematic.partSprite;
        durability = engineSchematic.durability;
        componentDrag = engineSchematic.componentDrag;
        operational = true;
    }
    private void Start()
    {
        InitComponent();
    }
}
