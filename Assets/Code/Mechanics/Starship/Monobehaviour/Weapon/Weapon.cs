// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  OCT 2018
// ----------------------------------------------------------------------------
using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    [SerializeField]
    private GameObject weaponPrefab;
    public GameObject WeaponPrefab
    {
        get { return weaponPrefab; }
        set { weaponPrefab = value; }
    }

    [SerializeField]
    private GameObject munitionPrefab;
    public GameObject MunitionPrefab
    {
        get { return munitionPrefab; }
        set { munitionPrefab = value; }
    }

    [SerializeField]
    private string weaponName;
    public string WeaponName
    {
        get { return weaponName; }
        set { weaponName = value; }
    }

    [SerializeField]
    private float weaponRange;
    public float WeaponRange
    {
        get { return weaponRange; }
        set { weaponRange = value; }
    }

    [SerializeField]
    private float weaponPower;
    public float WeaponPower
    {
        get { return weaponPower; }
        set { weaponPower = value; }
    }

    [SerializeField]
    private float weaponCooldown;
    public float WeaponCooldown
    {
        get { return weaponCooldown; }
        set { weaponCooldown = value; }
    }

    [SerializeField]
    private float weaponTimer;
    public float WeaponTimer
    {
        get { return weaponTimer; }
        set { weaponTimer = value; }
    }
    [SerializeField]
    private bool triggerTime;
    public bool TriggerTime
    {
        get { return triggerTime; }
        set { triggerTime = value; }
    }
    [SerializeField]
    private bool weaponReady;
    public bool WeaponReady
    {
        get { return weaponReady; }
        set { weaponReady = value; }
    }
}
