﻿// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  SEPT 2018
// ----------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [Serializable] public class FadeComplete : UnityEvent<bool> { }
    [Serializable] public class SceneChangeComplete : UnityEvent<bool> { }
    [Serializable] public class PlayerDeath : UnityEvent<bool> { }
    [Serializable] public class TargetDeath : UnityEvent<ActorController> { }
    [Serializable] public class ValidTargetScan : UnityEvent<ActorController> { }
    [Serializable] public class AcquiredTarget : UnityEvent<ActorController> { }
    [Serializable] public class TargetInSight : UnityEvent<ActorController> { }

}
