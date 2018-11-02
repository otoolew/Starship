using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : MonoBehaviour
{
    public StarshipSchematic starshipSchematic;
    public HullComponent hull;
    public EngineComponent[] engines;
    public WeaponComponent[] weapons;
    public SensorComponent sensor;

    [SerializeField]
    private float totalEnginePower;
    public float TotalEnginePower
    {
        get {
            for (int i = 0; i < engines.Length; i++)
            {
                totalEnginePower += starshipSchematic.engineSchematics[i].enginePower;
            }
            return totalEnginePower;
        }

    }
    public float TotalEngineThrust
    {
        get { return TotalEnginePower * 0.5f; }
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
                    maxWeaponRange = tempVal;
            }
            return minWeaponRange;
        }
    }
    [SerializeField]
    private float maxWeaponRange;
    public float MaxWeaponRange
    {
        get
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                float tempVal = starshipSchematic.weaponSchematics[i].weaponRange;
                if (tempVal > maxWeaponRange)
                    maxWeaponRange = tempVal;
            }
            return maxWeaponRange;
        }
    }
    #region Monobehaviour
    private void Awake()
    {
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
        // Sensor
        sensor.SensorSchematic = starshipSchematic.sensorSchematic;
        // Engines
        if (engines.Length == 0)
            return;
        for (int i = 0; i < engines.Length; i++)
        {
            engines[i].EngineSchematic = starshipSchematic.engineSchematics[i];
        }
        // Weapons
        if (weapons.Length == 0)
            return;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].WeaponSchematic = starshipSchematic.weaponSchematics[i];
            //weapons[i].FactionAlignment = controller.factionAlignment;
        }

    }

    #endregion
}
