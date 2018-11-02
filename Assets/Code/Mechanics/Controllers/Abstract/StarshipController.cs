using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The controls for a generic Actor to use.
/// </summary>
public abstract class StarshipController : MonoBehaviour
{
    public abstract Rigidbody RigidBody { get; set; }
    public abstract Starship Starship { get; set; }
    public abstract float RotationRate { get; set; }
    public abstract float MaxVelocity { get; set; }
    public abstract float ThrustPower { get; set; }
    public abstract float MaxWeaponRange { get; set; }
    public abstract float MinWeaponRange { get; set; }
    public abstract void FireWeapon(WeaponComponent weapon);
    public abstract void AccelerateStarship();
    public abstract void RotateStarship();
}
