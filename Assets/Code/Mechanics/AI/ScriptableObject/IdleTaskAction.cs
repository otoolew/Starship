using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newIdleTask", menuName = "AI/Task System/Idle")]
public class IdleTaskAction : TaskAction {

    public override void PerformTask(NPCController npcController)
    {
        npcController.DestinationController.UpdateDestination(npcController.transform);
    }
}
