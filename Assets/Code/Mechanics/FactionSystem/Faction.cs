using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction : MonoBehaviour
{
    public string factionName;

    [SerializeField]
    public FactionAlignment factionAlignment;

    private void Start()
    {
        factionName = factionAlignment.factionName;
    }
    public void ChangeFaction(FactionAlignment newFaction)
    {
        factionAlignment = newFaction;
    }
}
