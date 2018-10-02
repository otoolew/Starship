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
    //public WeaponSystem weaponSystem;

    [SerializeField]
    private GameObject _weaponPrefab;
    public GameObject WeaponPrefab
    {
        get { return _weaponPrefab; }
        set { _weaponPrefab = value; }
    }

    [SerializeField]
    private GameObject _munitionPrefab;
    public GameObject MunitionPrefab
    {
        get { return _munitionPrefab; }
        set { _munitionPrefab = value; }
    }

    [SerializeField]
    private string _weaponName;
    public string WeaponName
    {
        get { return _weaponName; }
        set { _weaponName = value; }
    }

    [SerializeField]
    private float _weaponRange;
    public float WeaponRange
    {
        get { return _weaponRange; }
        set { _weaponRange = value; }
    }

    [SerializeField]
    private float _weaponPower;
    public float WeaponPower
    {
        get { return _weaponPower; }
        set { _weaponPower = value; }
    }

    [SerializeField]
    private float _weaponCooldown;
    public float WeaponCooldown
    {
        get { return _weaponCooldown; }
        set { _weaponCooldown = value; }
    }

    [SerializeField]
    private float _weaponTimer;
    public float WeaponTimer
    {
        get { return _weaponTimer; }
        set { _weaponTimer = value; }
    }
    [SerializeField]
    private bool _triggerTime;
    public bool TriggerTime
    {
        get { return _triggerTime; }
        set { _triggerTime = value; }
    }
    [SerializeField]
    private bool _weaponReady;
    public bool WeaponReady
    {
        get { return _weaponReady; }
        set { _weaponReady = value; }
    }
}
