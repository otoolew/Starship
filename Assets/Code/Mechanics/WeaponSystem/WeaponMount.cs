using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMount : MonoBehaviour
{
    public FactionAlignment factionAlignment;


    // Use this for initialization
    void Start () {
        factionAlignment = GetComponentInParent<ActorController>().factionAlignment;
    }


	
}
