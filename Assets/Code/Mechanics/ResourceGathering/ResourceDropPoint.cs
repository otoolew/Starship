using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ResourceDropPoint : MonoBehaviour
{
    public CapitalStarship capitalShip;
    public List<ResourceField> resourceFields = new List<ResourceField>();
    public Text resourceLabel;
    public Faction faction;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cargo")
        {
            var starshipCargo = other.GetComponent<CargoComponent>();

            if (starshipCargo.Starship.controller.Faction.factionAlignment == faction.factionAlignment)
                capitalShip.totalResources += starshipCargo.UnloadCargo();
            resourceLabel.text = "$ " + capitalShip.totalResources;
        }
    }
}
