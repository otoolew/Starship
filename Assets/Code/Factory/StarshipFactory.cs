using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StarshipFactory
{
    #region Private
    //public static GameObject InstantiatePrefab(StarshipSchematic schematic)
    //{
    //    NPCController controller = Resources.Load<NPCController>("NPCController");
    //    GameObject starshipPrefab = Resources.Load<GameObject>(schematic.starshipRole.ToString());

    //    starshipPrefab.transform.parent = controller.transform;
    //    if (starshipPrefab == null)
    //    {
    //        Debug.LogError("No Prefab for name: " + schematic.starshipRole.ToString());
    //        return new GameObject(schematic.starshipRole.ToString());
    //    }
    //    GameObject instance = GameObject.Instantiate(starshipPrefab);
    //    instance.name = instance.name.Replace("(Clone)", "");
    //    return instance;
    //}

    public static NPCController InstantiatePrefab(StarshipSchematic schematic)
    {
        NPCController controller = Resources.Load<NPCController>("NPC_Starship");
        GameObject starshipPrefab = Resources.Load<GameObject>(schematic.starshipRole.ToString());

        if (starshipPrefab == null)
        {
            Debug.LogError("No Prefab for name: " + schematic.starshipRole.ToString());
            return null;
        }

        starshipPrefab.transform.parent = controller.transform;

        NPCController instance = NPCController.Instantiate(controller);
        instance.name = instance.name.Replace("(Clone)", "");
        return instance;
    }

    ////static void AddStats(GameObject obj)
    ////{
    ////    Stats s = obj.AddComponent<Stats>();
    ////    s.SetValue(StatTypes.LVL, 1, false);
    ////}

    //static void AddJob(GameObject obj, string name)
    //{
    //    GameObject instance = InstantiatePrefab("Jobs/" + name);
    //    instance.transform.SetParent(obj.transform);
    //    Job job = instance.GetComponent<Job>();
    //    job.Employ();
    //    job.LoadDefaultStats();
    //}
    #endregion
}
