using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceField : MonoBehaviour
{
    //[SerializeField]
    //private float disTimer;
    //public float SearchTimer
    //{
    //    get { return searchTimer; }
    //    private set { searchTimer = value; }
    //}
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerStay(Collider other)
    {
        try
        {
            var starshipCargo = other.GetComponent<CargoComponent>();

            starshipCargo.LoadCargo();
        }
        catch (NullReferenceException)
        {
            //Debug.Log("No Controller to target");
        }
    }

}
