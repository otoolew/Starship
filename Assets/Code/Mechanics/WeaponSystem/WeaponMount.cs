using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMount : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    public Weapon Weapon;
    public FactionAlignment factionAlignment;
    // Use this for initialization
    private void Awake()
    {
        
    }
    private void Start()
    {
        factionAlignment = GetComponentInParent<ActorController>().factionAlignment;
        Weapon = MountWeapon(weaponConfig);
    }

    // Update is called once per frame
    private void Update()
    {
        CooldownWeapon();
    }

    /// <summary>
    /// Used when LoadWeaponSystems is called.
    /// </summary>
    /// <param name="weaponSystem"></param>
    /// <returns></returns>
    private Weapon MountWeapon(WeaponConfig weaponSystem)
    {
        Weapon weapon = new Weapon
        {
            WeaponPrefab = weaponSystem.weaponPrefab,
            WeaponName = weaponSystem.weaponName,
            MunitionPrefab = weaponSystem.munitionPrefab,
            WeaponRange = weaponSystem.weaponRange,
            WeaponPower = weaponSystem.weaponPower,
            WeaponCooldown = weaponSystem.weaponCooldown,
            WeaponTimer = weaponSystem.weaponCooldown
        };
        return weapon;
    }

    private void CooldownWeapon()
    {     
        if (Weapon.WeaponTimer <= 0)
        {
            Weapon.WeaponTimer = 0;
            Weapon.WeaponReady = true;
        }
        else
        {
            Weapon.WeaponTimer -= Time.deltaTime;
            Weapon.WeaponReady = false;
        }
 
    }
    public void Fire()
    {
        if (Weapon.WeaponReady)
        {
            Instantiate(Weapon.MunitionPrefab, transform);
            Weapon.WeaponTimer = Weapon.WeaponCooldown;
            Weapon.WeaponReady = false;
        }
    }
}
