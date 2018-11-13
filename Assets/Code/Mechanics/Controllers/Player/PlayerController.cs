// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  NOV 2018
// ----------------------------------------------------------------------------
using System;
using UnityEngine;

public class PlayerController : StarshipController
{
    #region Properties and Variables
    [SerializeField]
    private Rigidbody rigidBody;
    public override Rigidbody RigidBody
    {
        get { return rigidBody; }
        set { rigidBody = value; }
    }
    [SerializeField]
    private Starship starship;
    public override Starship Starship
    {
        get { return starship; }
        set { starship = value; }
    }
    [SerializeField]
    private FactionAlignment faction;
    public override FactionAlignment Faction
    {
        get { return faction; }
        set { faction = value; }
    }
    [SerializeField]
    private CapitalStarship capitalStarship;
    public override CapitalStarship CapitalStarship
    {
        get { return capitalStarship; }
        set { capitalStarship = value; }
    }
    [SerializeField]
    private float rotationRate;
    public override float RotationRate
    {
        get { return rotationRate; }
        set { rotationRate = value; }
    }

    [SerializeField]
    private float maxVelocity;
    public override float MaxVelocity
    {
        get { return maxVelocity; }
        set { maxVelocity = value; }
    }

    [SerializeField]
    private float thrustPower;
    public override float ThrustPower
    {
        get { return thrustPower; }
        set { thrustPower = value; }
    }
    [SerializeField]
    private float maxWeaponRange;
    public override float MaxWeaponRange
    {
        get { return maxWeaponRange; }
        set { maxWeaponRange = value; }
    }

    [SerializeField]
    private float minWeaponRange;
    public override float MinWeaponRange
    {
        get { return minWeaponRange; }
        set { minWeaponRange = value; }
    }
    [SerializeField]
    private int loadedResources;
    public override int LoadedResources
    {
        get { return loadedResources; }
        set { loadedResources = value; }
    }
    [SerializeField]
    private bool dead;
    public override bool Dead
    {
        get { return dead; }
        set { dead = value; }
    }
    #endregion
    #region PlayerInput Props and Vars
    public float ThrustInput { get; set; }
    public float RotationInput { get; set; }
    public Vector3 EulerAngleVelocity { get; set; }
    #endregion

    #region Player Keys
    public KeyCode firePrimaryWeapon;
    #endregion

    #region EventHandlers
    public override event Action<StarshipController> removed;
    #endregion


    #region Monobehaviour
    /// <summary>
    /// This function is always called before any Start functions and also just after a prefab is instantiated.
    /// (If a GameObject is inactive during start up Awake is not called until it is made active.)
    /// </summary>
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        starship = GetComponentInChildren<Starship>();
    }
    /// <summary>
    /// (only called if the Object is active): This function is called just after the object is enabled. 
    /// This happens when a MonoBehaviour instance is created, such as when a level is loaded or a GameObjectwith the script component is instantiated.
    /// </summary>
    private void OnEnable()
    {

    }
    /// <summary>
    /// TODO: Implement in Abstract class
    /// Start is called before the first frame update only if the script instance is enabled.
    /// </summary>
    private void Start()
    {
        rotationRate = 180f;
        maxVelocity = starship.TotalEnginePower;
        thrustPower = starship.TotalEngineThrust;
        maxWeaponRange = starship.MaxWeaponRange;
        minWeaponRange = starship.MinWeaponRange;
        EulerAngleVelocity = new Vector3(0, RotationRate, 0);        
    }
    /// <summary>
    /// Update is called once per frame. It is the main workhorse function for frame updates.
    /// </summary>
    private void Update()
    {
        RotationInput = Input.GetAxis("Horizontal");
        ThrustInput = Input.GetAxis("Vertical");

        if (Input.GetKey(firePrimaryWeapon))
        {
            FireWeapon(starship.weapons[0]); //TODO: Make Dynamic
        }
    }
    /// <summary>
    /// All physics calculations and updates occur immediately after FixedUpdate. 
    /// </summary>
    void FixedUpdate()
    {
        AccelerateStarship();
        RotateStarship();
    }
    private void OnDisable()
    {

    }
    private void OnDestroy()
    {

    }
    #endregion
    public override void FireWeapon(WeaponComponent weapon)
    {
        weapon.Fire();
    }

    public override void AccelerateStarship()
    {
        if (ThrustInput >= 0)
            rigidBody.AddForce(transform.forward * ThrustInput * ThrustPower);

        // Limit Speed
        if (rigidBody.velocity.magnitude > MaxVelocity)
        {
            rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, MaxVelocity);
        }
    }

    public override void RotateStarship()
    {
        Quaternion rotation = Quaternion.Euler(EulerAngleVelocity * RotationInput * Time.deltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * rotation);
    }

    public override void HandleDeath()
    {
        removed.Invoke(this);
        gameObject.SetActive(false);
    }
}
