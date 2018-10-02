// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  SEPT 2018
// ----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventFadeComplete : UnityEvent<bool> { }
    [System.Serializable] public class EventSceneChangeComplete : UnityEvent<bool> { }
    [System.Serializable] public class EventPlayerDeath : UnityEvent<bool> { }

}
