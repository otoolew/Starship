using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskAction : ScriptableObject {

    public abstract void PerformTask(NPCController npcController);

}
