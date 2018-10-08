// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  SEPT 2018
// ----------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventFadeComplete : UnityEvent<bool> { }
    [System.Serializable] public class EventSceneChangeComplete : UnityEvent<bool> { }
    [System.Serializable] public class EventPlayerDeath : UnityEvent<bool> { }
    [System.Serializable] public class EventTargetDeath : UnityEvent<ActorController> { }
    [System.Serializable] public class EventValidTargetScan : UnityEvent<ActorController> { }
}
