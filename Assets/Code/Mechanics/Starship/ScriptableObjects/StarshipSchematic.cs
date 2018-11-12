using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newStarshipSchematic", menuName = "Starship Schematic")]
public class StarshipSchematic : ScriptableObject
{
    public string modelName;
    public HullSchematic hullSchematic;
    public EngineSchematic[] engineSchematics;
    public WeaponSchematic[] weaponSchematics;
    public CargoSchematic cargoSchematic;
}
