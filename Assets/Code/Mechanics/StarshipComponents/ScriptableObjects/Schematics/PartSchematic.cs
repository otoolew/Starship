using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartSchematic : ScriptableObject
{
    public string partName;
    public Enums.PartComponentType partType;
    public Sprite partSprite;
    public int HP;
}
