// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  SEPT 2018
// ----------------------------------------------------------------------------
using UnityEngine;

public class Munition : MonoBehaviour
{
    [Header("How long until I destroy myself?")]
    public float munitionRange;
    [Header("How fast do I go?")]
    public float munitionSpeed;
    [Header("How much damage do I do?")]
    public float munitionDamage;
    [Header("What do I collide with?")]
    public string[] collisionTags;

    public string ownerTag;
    // Use this for initialization
    void Start()
    {
        ownerTag = transform.parent.name;
        transform.parent = null;            // Unparent the bullet so it does not follow the Tank that fired it.
        Destroy(gameObject, munitionRange);      // Destroy me after a specified time.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * munitionSpeed); // Move Up over time by the speed
    }
    private void OnTriggerEnter(Collider collisonObject)
    {
        foreach (var collisionTag in collisionTags)
        {
            if (collisonObject.tag.Equals(collisionTag))
            {
                try
                {
                    collisonObject.GetComponent<HealthController>().TakeDamage(munitionDamage);
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
