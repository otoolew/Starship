using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for managing all Entities both player and npc
/// </summary>
public class EntityManager : Singleton<EntityManager>
{   
    #region Properties and Variables
    public List<StarshipController> starshipControllers = new List<StarshipController>();
    #endregion

    #region Events

    #endregion

    #region Handlers
    //private void HandleStarshipDeath(object sender, StarshipEventArgs e)
    //{
    //    StarshipController s = (StarshipController)sender;
    //    Debug.Log("Received event. Starship is removed from list " + e.StarshipController.name);
    //    // TODO: Remove from List
    //    RemoveStarshipController(s);
    //}
    #endregion


    #region Monobehaviour
    // Use this for initialization
    void Start()
    {
        StarshipController[] starshipControllerArray = FindObjectsOfType<StarshipController>();
        for (int i = 0; i < starshipControllerArray.Length; i++)
        {
            AddStarshipController(starshipControllerArray[i]);         
        }
    }

    // Update is called once per frame
    //void Update () {

    //}
    #endregion
    public void AddStarshipController(StarshipController s)
    {
        starshipControllers.Add(s);
    }

    public void RemoveStarshipController(StarshipController s)
    {
        starshipControllers.Remove(s);
    }

    public StarshipController FindClosestTarget(StarshipController s)
    {
        StarshipController starshipController = null;
        float closestDistance = 100f;
        for (int i = 0; i < starshipControllers.Count; i++)
        {
            if (s.Faction.factionAlignment.CanHarm(starshipControllers[i].Faction.factionAlignment))
            {
                float distance = Vector2.Distance(s.transform.position, starshipControllers[i].transform.position);
                if (distance < closestDistance)
                    starshipController = starshipControllers[i];
            }
        }
        return starshipController;
    }
}
