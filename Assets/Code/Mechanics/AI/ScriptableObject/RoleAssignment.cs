using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoleAssignment : ScriptableObject
{
    public abstract void PerformTask(NPCController npcController);
}
