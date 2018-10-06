using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newFactionAlignment", menuName = "FactionAlignment")]
[Serializable]
public class Faction : ScriptableObject
{
    [SerializeField]
    private string factionName;
    public string FactionName
    {
        get { return factionName; }
        set { factionName = value; }
    }

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public List<Faction> allies;
    public List<Faction> enemies;
}
