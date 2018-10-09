using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    [System.Serializable] public enum NPCState {IDLE, PATROL, ENGAGING }
    [System.Serializable] public enum WayPointType { LINKED, RANDOM, LOOP }
    [System.Serializable] public enum PointOfInterestType { TIMED, OBJECTIVE, LINGER }

}
