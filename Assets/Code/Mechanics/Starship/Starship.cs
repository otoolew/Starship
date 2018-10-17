using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : MonoBehaviour
{
    public ActorController controller;
    public StarshipSchematic starshipSchematic;
    public HullComponent hull;
    public EngineComponent[] engines;
    public WeaponComponent[] weapons;

    private void Awake()
    {
        BuildShip();
    }
    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BuildShip()
    {
        hull.HullSchematic = starshipSchematic.hullSchematic;
        BuildEngines();
        BuildWeapons();
    }
    private void BuildEngines()
    {
        if (weapons.Length == 0)
            return;
        for (int i = 0; i < engines.Length; i++)
        {          
            engines[i].EngineSchematic = starshipSchematic.engineSchematics[i];
        }
    }

    private void BuildWeapons()
    {
        if (weapons.Length == 0)
            return;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].WeaponSchematic = starshipSchematic.weaponSchematics[i];
            weapons[i].FactionAlignment = controller.factionAlignment;
        }
    }

}
