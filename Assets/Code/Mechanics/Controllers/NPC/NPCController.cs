// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  NOV 2018
// ----------------------------------------------------------------------------
using UnityEngine;
public class NPCController : StarshipController
{
    #region Variable Declarations
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

    public float Velocity
    {
        get { return GetComponent<Rigidbody>().velocity.magnitude; }
    }

    [SerializeField]
    private Transform navDestination;
    public Transform NavDestination
    {
        get { return navDestination; }
        private set { navDestination = value; }
    }

    [SerializeField]
    private float timer;
    public float Timer
    {
        get { return timer; }
        private set { timer = value; }
    }

    #endregion
    #region Events

    #endregion

    #region EventHandlers
    public void HandleAcquiredTarget(ShipController target)
    {
        Debug.Log(GetComponent<ShipController>() + " [NPCShipController] acquired " + target);
        if (target != null)
            navDestination = target.transform;
    }
    #endregion

    // Use this for initialization
    void Start ()
    {
        starship = GetComponentInChildren<Starship>();
        //targetController.onAcquiredTarget.AddListener(HandleAcquiredTarget);
    }
    #region Methods

    void UpdateDestination(Transform newDestination)
    {
        navDestination = newDestination;
    }
    private void OnDisable()
    {
        //onTargetDeath.Invoke(this);
    }
    private void OnDestroy()
    {
        
    }
    #endregion
    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        //TODO: FireWeapon(WeaponComponent weapon) When In Range
    }
    private void FixedUpdate()
    {

        if (navDestination != null)
        {
            // TODO: Fix Hard Code Stop Range 2.0f, Pace 1.0f
            if (((Vector2.Distance(navDestination.position, transform.position)) > 2.0f) && (timer > 1.0f))
            {
                AccelerateStarship();
                timer = 0;
            }

            RotateStarship();
        }

    }
    public override void AccelerateStarship()
    {
        rigidBody.AddForce((navDestination.position - transform.position) * ThrustPower);
        // Limit Speed
        if (rigidBody.velocity.magnitude > MaxVelocity)
        {
            rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, MaxVelocity);
        }
    }

    public override void RotateStarship()
    {
        Vector3 rotVector = navDestination.transform.position - transform.position;
        rotVector.y = 0f;
        Quaternion newRotation = Quaternion.LookRotation(rotVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * RotationRate);
    }
    public override void FireWeapon(WeaponComponent weapon)
    {
        throw new System.NotImplementedException();
    }
}
