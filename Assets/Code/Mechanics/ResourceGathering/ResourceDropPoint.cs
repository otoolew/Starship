using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropPoint : MonoBehaviour
{
    public CapitalStarship capitalShip;
    public List<ResourceField> resourceFields = new List<ResourceField>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Cargo")
        {
            try
            {
                CargoComponent starshipCargo = collider.GetComponent<CargoComponent>();

                if (starshipCargo.Controller.Faction == capitalShip.Faction)
                {
                    capitalShip.totalResources += starshipCargo.UnloadCargo();
                }

                Debug.Log("Capital Resources." + capitalShip.totalResources);
                //starshipCargo.Controller.GetComponent<DestinationController>().UpdateDestination(starshipCargo.Controller.CapitalStarship.resourceFields[0].transform);
            }
            catch (System.NullReferenceException)
            {
                Debug.Log("No CargoComponent Found.");
            }

        }

    }
}
