using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    private Rigidbody rigidBody;
    [SerializeField]
    private float _rotationRate;
    public float RotationRate
    {
        get { return _rotationRate; }
        set { _rotationRate = value; }
    }

    [SerializeField]
    private float _maxVelocity;
    public float MaxVelocity
    {
        get { return _maxVelocity; }
        set { _maxVelocity = value; }
    }

    [SerializeField]
    private float _thrustPower;
    public float ThrustPower
    {
        get { return _thrustPower; }
        set { _thrustPower = value; }
    }

    [SerializeField]
    private float _thrustInput;
    public float ThrustInput
    {
        get { return _thrustInput; }
        set { _thrustInput = value; }
    }

    [SerializeField]
    private float _rotationInput;
    public float RotationInput
    {
        get { return _rotationInput; }
        set { _rotationInput = value; }
    }

    [SerializeField]
    private Vector2 _axisInput;
    public Vector2 AxisInput
    {
        get
        {
            _axisInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return _axisInput;
        }
        private set { _axisInput = value; }
    }
    [SerializeField]
    private Vector3 _eulerAngleVelocity;
    public Vector3 EulerAngleVelocity
    {
        get { return _eulerAngleVelocity; }
        set { _eulerAngleVelocity = value; }
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

