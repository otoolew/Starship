using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullComponent : MonoBehaviour
{
    [SerializeField]
    private HullSchematic hullSchematic;
    public HullSchematic HullSchematic
    {
        get { return hullSchematic; }
        set { hullSchematic = value; }
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
    private void Start()
    {
        InitComponent();
    }
    public void InitComponent()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = hullSchematic.partSprite;
        durability = hullSchematic.durability;
        componentDrag = hullSchematic.componentDrag;
        operational = true;
    }
}
