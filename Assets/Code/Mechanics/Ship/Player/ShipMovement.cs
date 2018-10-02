// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  SEPT 2018
// ----------------------------------------------------------------------------
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    private Rigidbody rigidBody;
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
    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        EulerAngleVelocity = new Vector3(0, RotationRate, 0);
    }
    private void Update()
    {
        RotationInput = Input.GetAxis("Horizontal");
        ThrustInput = Input.GetAxis("Vertical");
    }
    // Update is called once per frame
    void FixedUpdate () {
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

}

