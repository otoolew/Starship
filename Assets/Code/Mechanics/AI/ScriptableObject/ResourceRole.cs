using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newResourceRole", menuName = "AI/Task System/Resource Role")]
public class ResourceRole : RoleAssignment
{
    public override void PerformTask(NPCController npcController)
    {
        // Call CapitolShip and ask for best ResourceField to Mine
        npcController.NavAgent.GoToPosition(npcController.CapitalStarship.resourceFields[0].transform.position);

        //if()
        //npcController.Starship.cargo.ResourcesLoaded
        //npcController.NavAgent.UpdateDestination(npcController.CapitalStarship.resourceFields[0].transform);
        //Debug.Log(npcController.name + " Performing Resource Role");
    }
}
