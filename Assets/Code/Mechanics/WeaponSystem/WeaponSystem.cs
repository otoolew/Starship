using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Weapon")]
public class WeaponSystem : ScriptableObject
{
    public GameObject weaponPrefab;
    public GameObject munitionPrefab;
    public string weaponName;
    public float weaponRange;
    public float weaponPower;
    public float weaponCooldown;
}
