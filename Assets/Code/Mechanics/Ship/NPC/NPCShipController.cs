// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  SEPT 2018
// ----------------------------------------------------------------------------
using UnityEngine;

public class NPCShipController : MonoBehaviour
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
        
        if (((Vector2.Distance(target.position, transform.position)) > EngagementRange) && (timer > pace))
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
        Vector3 rotVector = target.transform.position - transform.position;
        rotVector.y = 0f;
        Quaternion newRotation = Quaternion.LookRotation(rotVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * RotationRate);
    }
}
