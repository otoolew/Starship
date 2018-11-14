using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : MonoBehaviour
{
    public StarshipController controller;

    public StarshipSchematic starshipSchematic;
    public HullComponent hull;
    public EngineComponent[] engines;
    public WeaponComponent[] weapons;
    public CargoComponent cargo;

    public float TotalEnginePower { get; set; }

    public float TotalEngineThrust
    {
        get { return TotalEnginePower * 2f; }
    }

    [SerializeField]
    private float minWeaponRange;
    public float MinWeaponRange
    {
        get
        {
            minWeaponRange = starshipSchematic.weaponSchematics[0].weaponRange;
            for (int i = 0; i < engines.Length; i++)
            {
                float tempVal = starshipSchematic.weaponSchematics[i].weaponRange;
                if (tempVal < minWeaponRange)
                    minWeaponRange = tempVal;
            }
            return minWeaponRange;
        }
    }

    public float MaxWeaponRange { get; set; }

    #region Monobehaviour
    private void Awake()
    {
        controller = GetComponentInParent<StarshipController>();
        BuildShip();

    }
    private void Start()
    {
        
    }
    #endregion
    #region Init
    private void BuildShip()
    {
        // Hull
        hull.HullSchematic = starshipSchematic.hullSchematic;

        hull.onHullDisabled.AddListener(HandleHullDisabled); // Subscribe

        // Cargo
        cargo.CargoSchematic = starshipSchematic.cargoSchematic;
        // Engines
        if (engines.Length == 0)
            return;
        for (int i = 0; i < engines.Length; i++)
        {
            engines[i].EngineSchematic = starshipSchematic.engineSchematics[i];
            engines[i].onEngineDisabled.AddListener(HandleEngineDisabled); // Subscribe or Listen for EventSceneChangeStart        
            TotalEnginePower += starshipSchematic.engineSchematics[i].enginePower;
            
        }
        // Weapons
        if (weapons.Length == 0)
            return;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].WeaponSchematic = starshipSchematic.weaponSchematics[i];

            if (weapons[i].WeaponSchematic.weaponRange > MaxWeaponRange)
                MaxWeaponRange = weapons[i].WeaponSchematic.weaponRange;

            weapons[i].onWeaponDisabled.AddListener(HandleWeaponDisabled);
        }
    }
    private void HandleHullDisabled(HullComponent disabledHull)
    {
        Debug.Log(disabledHull.name + " is disabled. TODO: Implement Death");
        controller.HandleDeath();
    }
    private void HandleWeaponDisabled(WeaponComponent disabledWeapon)
    {
        disabledWeapon.GetComponent<Collider>().enabled = false;
        Debug.Log(disabledWeapon.name + " is disabled. TODO: Implement what happens next");
    }
    private void HandleEngineDisabled(EngineComponent disabledEngine)
    {
        disabledEngine.GetComponent<Collider>().enabled = false;
        TotalEnginePower -= disabledEngine.EnginePower;
        controller.ThrustPower = TotalEngineThrust;
    }
    #endregion
}
