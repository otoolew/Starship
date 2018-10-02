using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWeaponController : MonoBehaviour
{
    public WeaponSystem[] weaponSystems;
    public Transform firePoint;

    [SerializeField]
    private GameObject _loadedWeapon;
    public GameObject LoadedWeapon
    {
        get { return _loadedWeapon; }
        private set { _loadedWeapon = value; }
    }

    [SerializeField]
    private float _weaponCooldown;
    public float WeaponCooldown
    {
        get { return _weaponCooldown; }
        set { _weaponCooldown = value;}
    }

    [SerializeField]
    private float _timer;
    public float Timer
    {
        get { return _timer; }
        set { _timer = value; }
    }

    [SerializeField]
    private float _weaponReady;
    public float WeaponReady
    {
        get { return _weaponReady; }
        set { _weaponReady = value; }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < WeaponCooldown)
        {
            
            Fire();
        }
    }

    private void LoadWeapon(WeaponSystem nextWeapon)
    {
        //LoadedWeapon = weaponSystem
    }
    private void Fire()
    {
        //Instantiate(weaponSystem.bulletPrefab, firePoint);
    }
}
