using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StarshipComponent : MonoBehaviour
{
    public abstract void ApplyDamage(int amount);
    public abstract void RepairDamage(int amount);
}
