using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    [Serializable] public enum NPCState {IDLE, PATROL, ENGAGING }
    [Serializable] public enum WayPointType { LINKED, RANDOM, LOOP }
    [Serializable] public enum PointOfInterestType { TIMED, OBJECTIVE, LINGER }
    [Serializable] public enum ItemType { NONE, COLLECTABLE, EQUIPPABLE, MISC};
    [Serializable] public enum EquipableItemType { WEAPON, ARMOR, UTILITY, ENGINE };
}
