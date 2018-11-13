using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newCombatRole", menuName = "AI/Task System/Comabat Role")]
public class CombatRole : RoleAssignment
{
    public override void PerformTask(NPCController npcController)
    {
        Debug.Log(npcController.name + " Performing Combat Role");
    }
}
