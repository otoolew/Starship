using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShipController : MonoBehaviour
{
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
    private Vector3 _eulerAngleVelocity;
    public Vector3 EulerAngleVelocity
    {
        get { return _eulerAngleVelocity; }
        set { _eulerAngleVelocity = value; }
    }
    public Transform target;
    public float EngagementRange;
    // Use this for initialization
    [SerializeField]
    private float timer;
    public float pace;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        target = FindObjectOfType<ShipMovement>().transform;
    }
    private void Update()
    {
        timer += Time.deltaTime;

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        var distance = Vector3.Distance(target.position, transform.position);
        if (((Vector3.Distance(target.position, transform.position)) > EngagementRange) && (timer>pace))
        {
            Accelerate();
            timer = 0;
        }

        Turn();
    }

    private void Accelerate()
    {
        rigidBody.AddForce((target.position - transform.position) * ThrustPower);
        // Limit Speed
        if (rigidBody.velocity.magnitude > MaxVelocity)
        {
            rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, MaxVelocity);
        }
    }

    private void Turn()
    {
        Vector3 targetDir = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = RotationRate * Time.deltaTime;
        Vector3 adjustedDir = new Vector3(0.0f, targetDir.y, 0.0f);
        Vector3 newDir = Vector3.RotateTowards(transform.up, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);

    }
}
