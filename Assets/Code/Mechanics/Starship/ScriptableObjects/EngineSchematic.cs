using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newEngineSchematic", menuName = "Starship Parts/Engine Schematic")]
public class EngineSchematic : PartSchematic
{
    public GameObject trusterPrefab;
    public float trustPower;
}
