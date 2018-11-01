// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  NOV 2018
// ----------------------------------------------------------------------------
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
    public Events.WeaponDisabled partDisabled;
    #endregion

    /// <summary>
    /// Init Components
    /// </summary>
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        starship = GetComponentInChildren<Starship>();
    }
    /// <summary>
    /// Init Properties
    /// </summary>
    private void Start()
    {
        rotationRate = 180f;
        maxVelocity = starship.TotalEnginePower;
        thrustPower = starship.TotalEngineThrust;
        EulerAngleVelocity = new Vector3(0, RotationRate, 0);

    }
    private void Update()
    {
        RotationInput = Input.GetAxis("Horizontal");
        ThrustInput = Input.GetAxis("Vertical");

        if (Input.GetKey(firePrimaryWeapon))
        {
            FireWeapon(starship.weapons[0]); //TODO: Make Dynamic
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        AccelerateStarship();
        RotateStarship();
    }

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
}
