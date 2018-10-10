using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Weapon Configuration")]
public class WeaponConfig : ScriptableObject
{
    public GameObject weaponPrefab;
    public GameObject munitionPrefab;
    public string weaponName;
    public float weaponRange;
    public float weaponPower;
    public float weaponCooldown;

}