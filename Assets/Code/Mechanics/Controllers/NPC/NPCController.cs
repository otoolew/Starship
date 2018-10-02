// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  SEPT 2018
// ----------------------------------------------------------------------------
using UnityEngine;

public class NPCController : MonoBehaviour {
    public string NPCName;

    [SerializeField]
    private NPCShipController shipController;
    public NPCShipController ShipController
    {
        get { return shipController; }
        private set { shipController = value; }
    }

    [SerializeField]
    private NPCWeaponController weaponController;
    public NPCWeaponController WeaponController
    {
        get { return weaponController; }
        private set { weaponController = value; }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
