using System.Collections;
using System.Collections.Generic;
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
    public WeaponController weaponController;
    // Use this for initialization
    void Start ()
    {
        weaponController = FindObjectOfType<WeaponController>();
        weaponName.text = weaponController.WeaponList[slot].WeaponName;
    }
	
	// Update is called once per frame
	void Update ()
    {
        weaponCooldown.text = ""+weaponController.WeaponList[slot].WeaponTimer;
    }
}
