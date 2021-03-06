﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StarshipComponent : MonoBehaviour
{
    public abstract StarshipController Controller { get; set; }
    public abstract void ApplyDamage(int amount);
    public abstract void RepairDamage(int amount);
    public abstract void DisableEffect();
}
