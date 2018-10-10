// ----------------------------------------------------------------------------
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
    public WeaponController weaponController;
    // Use this for initialization
    void Start ()
    {
        weaponController = FindObjectOfType<WeaponController>();
        weaponName.text = weaponController.MountedWeaponList[slot].Weapon.WeaponName;
    }
	
	// Update is called once per frame
	void Update ()
    {
        weaponCooldown.text = "" + weaponController.MountedWeaponList[slot].Weapon.WeaponTimer;
    }
}
