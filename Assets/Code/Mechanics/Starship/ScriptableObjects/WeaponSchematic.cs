using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newWeaponSchematic", menuName = "Starship Parts/Weapon Schematic")]
public class WeaponSchematic : PartSchematic
{
    public GameObject munitionPrefab;
    public float weaponRange;
    public float weaponPower;
    public float weaponCooldown;
}
