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
    public int munitionDamage;
    [Header("Who do I belong to?")]
    public Faction owningFaction;

    private void Awake()
    {
        

    }
    // Use this for initialization
    private void Start()
    {
        owningFaction = GetComponentInParent<WeaponComponent>().Starship.controller.Faction;
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

        if (collisonObject.CompareTag("Impact"))
        {
            Destroy(gameObject);
            return;
        }

        try
        {
            StarshipComponent componentHit = collisonObject.GetComponent<StarshipComponent>();


            if (owningFaction.factionAlignment.CanHarm(componentHit.Starship.controller.Faction.factionAlignment))
                componentHit.ApplyDamage(munitionDamage);
        }
        catch (System.NullReferenceException)
        {
            //Debug.Log("No StarshipComponent Found.");
        }
        Destroy(gameObject); // TODO: Deactivate and return to Pool
    }
}
