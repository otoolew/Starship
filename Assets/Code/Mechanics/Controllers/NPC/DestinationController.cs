using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationController : MonoBehaviour
{
    [SerializeField]
    private Transform navDestination;
    public Transform NavDestination
    {
        get { return navDestination; }
        private set { navDestination = value; }
    }
    [SerializeField]
    private Transform homeBase;
    public Transform HomeBase
    {
        get { return homeBase; }
        private set { homeBase = value; }
    }
    // Use this for initialization
    void Start () {
        navDestination = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void UpdateDestination(Transform newDestination)
    {
        navDestination = newDestination;
    }
}
