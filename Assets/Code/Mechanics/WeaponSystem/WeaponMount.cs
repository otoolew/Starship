using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMount : MonoBehaviour
{
    public string Owner;
    public string FactionName;
    public List<Faction> DestroyList = new List<Faction>();
    public ActorController controller;
    // Use this for initialization
    void Start () {
        Owner = controller.ActorName;
        DestroyList = controller.faction.enemies;
        FactionName = controller.faction.FactionName;
    }
	
}
