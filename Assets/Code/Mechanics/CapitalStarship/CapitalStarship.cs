using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalStarship : MonoBehaviour
{
    [SerializeField]
    private Faction faction;
    public Faction Faction
    {
        get { return faction; }
        set { faction = value; }
    }
    public int totalResources;

    [SerializeField]
    public ResourceField PriorityResourceField { get; set; }

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
