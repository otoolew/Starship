using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalStarship : MonoBehaviour
{
    [SerializeField]
    private FactionAlignment faction;
    public FactionAlignment Faction
    {
        get { return faction; }
        set { faction = value; }
    }
    public int totalResources;

    public List<ResourceField> resourceFields = new List<ResourceField>();
    [SerializeField]
    private Transform resourceDropPoint;
    public Transform ResourceDropPoint
    {
        get { return resourceDropPoint; }
        set { resourceDropPoint = value; }
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
