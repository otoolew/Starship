﻿// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  OCT 2018
// ----------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public KeyCode firePrimaryKey;
    public KeyCode fireSecondaryKey;

    public List<WeaponComponent> WeaponComponentList = new List<WeaponComponent>();

    private void Awake()
    {
        
    }
    // Use this for initialization
    private void Start ()
    {

    }
	
	// Update is called once per frame
	private void Update ()
    {

        if (Input.GetKey(firePrimaryKey))
        {
            WeaponComponentList[0].Fire();
            //LoadWeapon(WeaponList[0]);
        }
        //if (Input.GetKey(fireSecondaryKey))
        //{
        //    WeaponComponentList[1].Fire();
        //}
    }
}