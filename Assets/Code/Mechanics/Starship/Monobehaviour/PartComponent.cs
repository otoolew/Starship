using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartComponent<T> : MonoBehaviour where T : PartComponent<T>
{
    public T partSchematic = default(T);

    [SerializeField]
    private Enums.PartComponentType partType;
    public virtual Enums.PartComponentType PartType
    {
        get { return partType; }
        private set { partType = value; }
    }
    [SerializeField]
    private float durability;
    public virtual float Durability
    {
        get { return durability; }
        private set { durability = value; }
    }
    [SerializeField]
    private float componentDrag;
    public virtual float ComponentDrag
    {
        get { return componentDrag; }
        private set { componentDrag = value; }
    }
    [SerializeField]
    private bool operational;
    public virtual bool Operational
    {
        get { return operational; }
        private set { operational = value; }
    }
    public virtual void InitComponent()
    {
        partType = partSchematic.partType;
        durability = partSchematic.durability;
        componentDrag = partSchematic.componentDrag;
        operational = true;
    }
}
