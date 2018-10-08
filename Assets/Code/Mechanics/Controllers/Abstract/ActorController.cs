using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is used to ID important data used in checks like collisions and layers
/// </summary>
public abstract class ActorController : MonoBehaviour
{
    //TODO: ScriptableObject Data Container
    public string ActorName;
    public FactionAlignment factionAlignment;
    public Events.EventTargetDeath onTargetDeath;
}
