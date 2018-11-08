using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StarshipFactory
{
    #region Public
    public static GameObject Create(string name)
    {
        StarshipSchematic schematic = Resources.Load<StarshipSchematic>("Schematics/Starships/" + name);
        if (schematic == null)
        {
            Debug.LogError("No Unit Recipe for name: " + name);
            return null;
        }
        return Create(schematic);
    }

    public static GameObject Create(StarshipSchematic schematic)
    {
        GameObject obj = InstantiatePrefab("Prefabs/Starships/" + schematic.name);
        obj.name = schematic.name;
        return obj;
    }
    #endregion

    #region Private
    static GameObject InstantiatePrefab(string name)
    {
        GameObject prefab = Resources.Load<GameObject>(name);
        if (prefab == null)
        {
            Debug.LogError("No Prefab for name: " + name);
            return new GameObject(name);
        }
        GameObject instance = GameObject.Instantiate(prefab);
        instance.name = instance.name.Replace("(Clone)", "");
        return instance;
    }

    //static void AddStats(GameObject obj)
    //{
    //    Stats s = obj.AddComponent<Stats>();
    //    s.SetValue(StatTypes.LVL, 1, false);
    //}

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
