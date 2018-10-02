// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  OCT 2018
// ----------------------------------------------------------------------------
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string PlayerName;

    [SerializeField]
    private ShipMovement shipController;
    public ShipMovement ShipController
    {
        get { return shipController; }
        private set { shipController = value; }
    }

    [SerializeField]
    private WeaponController weaponController;
    public WeaponController WeaponController
    {
        get { return weaponController; }
        private set { weaponController = value; }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
