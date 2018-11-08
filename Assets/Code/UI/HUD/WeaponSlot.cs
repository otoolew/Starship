﻿// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  OCT 2018
// ----------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TODO: Needs to be more robust.
/// </summary>
public class WeaponSlot : MonoBehaviour
{
    public int slot;
    public Text weaponName;
    public Text weaponCooldown;
    public PlayerController playerController;

    // Use this for initialization
    void Start ()
    {
        playerController = FindObjectOfType<PlayerController>();
        weaponName.text = playerController.Starship.weapons[slot].WeaponSchematic.partName;f
    }
	
	// Update is called once per frame
	void Update ()
    {
        weaponCooldown.text = "" + playerController.Starship.weapons[slot].WeaponTimer;
    }
}
