using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShipStats", menuName = "Ship/Stats")]
public class ShipStats : ScriptableObject
{
    public string shipModel;
    public int thrustPower;
    [Range(30,270)]
    public int handling;
    public int hullArmor;
    public int hullIntegrity;
}
