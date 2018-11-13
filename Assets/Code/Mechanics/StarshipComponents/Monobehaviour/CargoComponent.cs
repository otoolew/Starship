using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoComponent : StarshipComponent
{

    #region Variable Declarations
    [SerializeField]
    private CargoSchematic cargoSchematic;
    public CargoSchematic CargoSchematic
    {
        get { return cargoSchematic; }
        set { cargoSchematic = value; }
    }
    [SerializeField]
    private StarshipController controller;
    public override StarshipController Controller
    {
        get { return controller; }
        set { controller = value; }
    }
    [SerializeField]
    private int cargoLoadCapacity;
    public int CargoLoadCapacity
    {
        get { return cargoLoadCapacity; }
        set { cargoLoadCapacity = value; }
    }
    [SerializeField]
    private float cargoLoadCooldown;
    public float CargoLoadCooldown
    {
        get { return cargoLoadCooldown; }
        private set { cargoLoadCooldown = value; }
    }
    [SerializeField]
    private float cargoLoadTimer;
    public float CargoLoadTimer
    {
        get { return cargoLoadTimer; }
        set { cargoLoadTimer = value; }
    }

    [SerializeField]
    private bool cargoLoadReady;
    public bool CargoLoadReady
    {
        get { return cargoLoadReady; }
        set { cargoLoadReady = value; }
    }

    [SerializeField]
    private int resourcesLoaded;

    [SerializeField]
    private float hP;
    public float HP
    {
        get { return hP; }
        private set { hP = value; }
    }

    [SerializeField]
    private bool operational;
    public bool Operational
    {
        get { return operational; }
        private set { operational = value; }
    }

    #endregion

    #region Init
    public void InitComponent()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = cargoSchematic.partSprite;

        CargoLoadCooldown = cargoSchematic.cargoLoadCooldown;
        CargoLoadTimer = cargoSchematic.cargoLoadCooldown;
        CargoLoadCapacity = cargoSchematic.cargoLoadCapacity;
        Operational = true;
    }
    #endregion

    #region Monobehaviour
    // Use this for initialization
    private void Awake()
    {

    }
    private void Start()
    {
        InitComponent();
    }
    private void Update()
    {

    }
    #endregion
    public void LoadCargo()
    {
        if (operational)
        {
            CooldownCargoLoader();
        }
        if (cargoLoadReady)
        {
            resourcesLoaded++;
            cargoLoadTimer = cargoLoadCooldown;
            if(resourcesLoaded > CargoLoadCapacity)
            {
                try
                {
                    controller.GetComponent<DestinationController>().UpdateDestination(controller.CapitalStarship.ResourceDropPoint);
                }
                catch (System.Exception)
                {
                    Debug.Log("Player Cargo");
                }

            }
        }
    }
    public int UnloadCargo()
    {
        int amount = resourcesLoaded;
        resourcesLoaded = 0;
        try
        {
            controller.GetComponent<DestinationController>().UpdateDestination(controller.CapitalStarship.resourceFields[0].transform);
        }
        catch (System.Exception)
        {
            Debug.Log("Player Cargo");
        }
        return amount;
    }
    private void CooldownCargoLoader()
    {
        if (cargoLoadTimer <= 0)
        {
            cargoLoadTimer = 0;
            cargoLoadReady = true;
        }
        else
        {
            cargoLoadTimer -= Time.deltaTime;
            cargoLoadReady = false;
        }

    }
    public override void ApplyDamage(int amount)
    {
        hP -= amount;
    }

    public override void RepairDamage(int amount)
    {
        hP += amount;
    }
    public override void DisableEffect()
    {
        // Eject Resources
        throw new System.NotImplementedException();
    }
}
