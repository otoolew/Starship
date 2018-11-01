using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField]
    private Starship starship;
    public Starship Starship
    {
        get { return starship; }
        set { starship = value; }
    }

    public KeyCode firePrimaryWeapon;

    [SerializeField]
    private float rotationRate;
    public float RotationRate
    {
        get { return rotationRate; }
        set { rotationRate = value; }
    }

    [SerializeField]
    private float maxVelocity;
    public float MaxVelocity
    {
        get { return maxVelocity; }
        set { maxVelocity = value; }
    }

    [SerializeField]
    private float thrustPower;
    public float ThrustPower
    {
        get { return thrustPower; }
        set { thrustPower = value; }
    }

    [SerializeField]
    private float thrustInput;
    public float ThrustInput
    {
        get { return thrustInput; }
        set { thrustInput = value; }
    }

    [SerializeField]
    private float rotationInput;
    public float RotationInput
    {
        get { return rotationInput; }
        set { rotationInput = value; }
    }

    [SerializeField]
    private Vector2 axisInput;
    public Vector2 AxisInput
    {
        get
        {
            axisInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return axisInput;
        }
        private set { axisInput = value; }
    }
    [SerializeField]
    private Vector3 eulerAngleVelocity;
    public Vector3 EulerAngleVelocity
    {
        get { return eulerAngleVelocity; }
        set { eulerAngleVelocity = value; }
    }

    #region EventHandlers
    public Events.WeaponDisabled partDisabled;
    #endregion

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        starship = GetComponentInChildren<Starship>();
        EulerAngleVelocity = new Vector3(0, RotationRate, 0);

        foreach (var engine in starship.engines)
        {
            MaxVelocity += engine.EngineSchematic.enginePower;
            engine.onEngineDisabled.AddListener(HandleEngineDisabled);
        }
        foreach (var weapon in starship.weapons)
        {
            weapon.onWeaponDisabled.AddListener(HandleWeaponDisabled);
        }
        ThrustPower = MaxVelocity;
    }

    private void Update()
    {
        RotationInput = Input.GetAxis("Horizontal");
        ThrustInput = Input.GetAxis("Vertical");
        if (Input.GetKey(firePrimaryWeapon))
        {
            if(starship.weapons[0].Operational)
                starship.weapons[0].Fire();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Accelerate();
        Turn();
    }

    private void Accelerate()
    {
        if (ThrustInput >= 0)
            rigidBody.AddForce(transform.forward * ThrustInput * ThrustPower);

        // Limit Speed
        if (rigidBody.velocity.magnitude > MaxVelocity)
        {
            rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, MaxVelocity);
        }

    }

    private void Turn()
    {
        Quaternion rotation = Quaternion.Euler(EulerAngleVelocity * RotationInput * Time.deltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * rotation);
    }

    public void HandleEngineDisabled(EngineComponent engine)
    {
        maxVelocity -= engine.EnginePower;
        thrustPower = thrustPower * 0.5f;
    }
    public void HandleWeaponDisabled(WeaponComponent weapon)
    {
        Debug.Log("Weapon " + weapon.WeaponSchematic.partName + " is disabled");
    }
}
