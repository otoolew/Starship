// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  SEPT 2018
// ----------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// TODO: Make this a Pooled GO
/// </summary>
public class Munition : MonoBehaviour
{
    [Header("How long until I destroy myself?")]
    public float munitionRange;
    [Header("How fast do I go?")]
    public float munitionSpeed;
    [Header("How much damage do I do?")]
    public float munitionDamage;
    [Header("Who do I belong to?")]
    public FactionAlignment factionAlignment;

    // Use this for initialization
    private void Start()
    {
        factionAlignment = GetComponentInParent<WeaponMount>().factionAlignment;
        transform.parent = null;            // Unparent the bullet so it does not follow the Tank that fired it.
        Destroy(gameObject, munitionRange);      // Destroy me after a specified time.
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * munitionSpeed); // Move Up over time by the speed
    }

    private void OnTriggerEnter(Collider collisonObject)
    {
        try
        {         
            ActorController actorHit = collisonObject.GetComponent<ActorController>();
            if (factionAlignment.CanHarm(actorHit.factionAlignment))
            {
                Destroy(collisonObject.gameObject);
                Destroy(gameObject);
            }
        }
        catch (System.NullReferenceException)
        {
            Debug.Log("No CollisionTag Found");
        }

    }
}
