using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    [Serializable] public enum NPCState {IDLE, PATROL, ENGAGING }
    [Serializable] public enum WayPointType { LINKED, RANDOM, LOOP }
    [Serializable] public enum StarshipRole { FIGHTER, MINER }
    [Serializable] public enum PartComponentType { WEAPON, HULL, ENGINE, UTILITY };
    [Serializable] public enum ItemType { NONE, COLLECTABLE, EQUIPPABLE, MISC};
}
