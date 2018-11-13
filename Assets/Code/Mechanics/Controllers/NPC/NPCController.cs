// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  NOV 2018
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
public class NPCController : StarshipController
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

    #region NPC Logic Props and Vars
    [SerializeField]
    private DestinationController destinationController;
    public DestinationController DestinationController
    {
        get { return destinationController; }
        private set { destinationController = value; }
    }

    [SerializeField]
    private TargetController targetController;
    public TargetController TargetController
    {
        get { return targetController; }
        private set { targetController = value; }
    }

    [SerializeField]
    private float thrustPace;
    public float ThrustPace
    {
        get { return thrustPace; }
        private set { thrustPace = value; }
    }

    [SerializeField]
    private float stopDistance;
    public float StopDistance
    {
        get { return stopDistance; }
        private set { stopDistance = value; }
    }

    public Vector3 EulerAngleVelocity { get; set; }

    public override event Action<StarshipController> removed;

    float timer;
    #endregion

    #region Events

    #endregion
    #region Role Assignment
    [SerializeField]
    private RoleAssignment assignedRole;
    public RoleAssignment AssignedRole
    {
        get { return assignedRole; }
        private set { assignedRole = value; }
    }
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
        assignedRole.PerformTask(this);
    }
    /// <summary>
    /// Update is called once per frame. It is the main workhorse function for frame updates.
    /// </summary>
    private void Update()
    {
        timer += Time.deltaTime;

        // TODO: NPC's fire even when not aiming at target
        if (targetController.CurrentTarget != null)
        {            
            for (int i = 0; i < starship.weapons.Length; i++)
            {
                FireWeapon(starship.weapons[i]);
            }
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
        if (!weapon.Operational)
            return;
        if (((Vector2.Distance(transform.position, targetController.CurrentTarget.transform.position)) < maxWeaponRange))
        {
            weapon.Fire();
        }

    }

    public override void AccelerateStarship()
    {
        if (targetController.CurrentTarget != null)
        {
            if (((Vector2.Distance(transform.position, targetController.CurrentTarget.transform.position)) > maxWeaponRange) && (timer > thrustPace))
            {
                rigidBody.AddForce((targetController.CurrentTarget.transform.position - transform.position) * ThrustPower);
                timer = 0;
            }
        }
        else
        {
            if((Vector2.Distance(transform.position, destinationController.NavDestination.position)) > stopDistance)
            {
                if (timer > thrustPace)
                {
                    rigidBody.AddForce((destinationController.NavDestination.position - transform.position) * ThrustPower);
                    timer = 0;
                }
            }
        }

        // Limit Speed
        if (rigidBody.velocity.magnitude > MaxVelocity)
        {
            rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, MaxVelocity);
        }
    }

    public override void RotateStarship()
    {
        Vector3 rotVector = Vector3.zero;

        if (targetController.CurrentTarget != null)
            rotVector = targetController.CurrentTarget.transform.position - transform.position;
        else
            rotVector = destinationController.NavDestination.position - transform.position;

        if(rotVector != Vector3.zero)
        {
            rotVector.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(rotVector);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * RotationRate);
        }
    }

    //public void CargoEmpty()
    //{
    //    destinationController.UpdateDestination(capitalStarship.resourceFields[0].transform);
    //}

    public override void HandleDeath()
    {
        removed.Invoke(this);
        Destroy(this);
    }
    void OnDrawGizmosSelected()
    {

    }
}
