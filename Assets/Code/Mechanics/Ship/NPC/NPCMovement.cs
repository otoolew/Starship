using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {
    private Rigidbody2D rb2D;


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

    public float floatHeight;
    public float liftForce;
    public float damping;


    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider != null)
        {
            Debug.Log("hit! " + hit.collider.name);
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            rb2D.AddForce(Vector3.up * ThrustPower);
        }

        Accelerate();
        Turn();
    }

    private void Accelerate()
    {
        //if (ThrustInput >= 0)
        //    rb2D.AddForce(transform.up * ThrustInput * ThrustPower);

        // Limit Speed
        if (rb2D.velocity.magnitude > MaxVelocity)
        {
            rb2D.velocity = Vector3.ClampMagnitude(rb2D.velocity, MaxVelocity);
        }

    }

    private void Turn()
    {
        //rb2D.MoveRotation(rb2D.rotation + -RotationInput * RotationRate * Time.fixedDeltaTime);
    }
}
