using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBolt : MonoBehaviour {

    [Header("How long until I destroy myself?")]
    public float boltRange;
    [Header("How fast do I go?")]
    public float boltSpeed;
    [Header("How much damage do I do?")]
    public float boltDamage;
    [Header("What do I collide with?")]
    public string[] collisionTags;

    // Use this for initialization
    void Start()
    {
        transform.parent = null;            // Unparent the bullet so it does not follow the Tank that fired it.
        Destroy(gameObject, boltRange);      // Destroy me after a specified time.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * boltSpeed); // Move Up over time by the speed
    }
    private void OnTriggerEnter(Collider collisonObject)
    {
        foreach (var collisionTag in collisionTags)
        {
            if (collisonObject.tag.Equals(collisionTag))
            {
                try
                {
                    collisonObject.GetComponent<HealthController>().TakeDamage(boltDamage);
                }
                catch (System.NullReferenceException)
                {
                    Debug.Log("LaserBolt:NullCatch => No HealthController");
                    Destroy(collisonObject.gameObject);
                }
                
                Destroy(gameObject);                // Destroy myself!
            }
        }
    }
}

