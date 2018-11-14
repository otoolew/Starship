using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceField : MonoBehaviour
{
    [Header("Owning Faction")]
    public Faction faction;

    [Header("Controlling Capital Starship")]
    public CapitalStarship capitalStarship;

    public int ResourceAmount { get; set; }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cargo")
        {
            try
            {
                var starshipCargo = other.GetComponent<CargoComponent>();
    
                if (starshipCargo.Starship.controller.Faction.factionAlignment == faction.factionAlignment)
                    starshipCargo.LoadCargo();
            }
            catch (NullReferenceException)
            {
                Debug.Log("ResourceField Throw");
            }           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cargo")
        {
            try
            {
                var starshipCargo = other.GetComponent<CargoComponent>();

                if (starshipCargo.Starship.controller.Faction.factionAlignment == faction.factionAlignment)
                    starshipCargo.LoadCargo();
            }
            catch (NullReferenceException)
            {
                Debug.Log("ResourceField Throw");
            }
        }
    }

}
