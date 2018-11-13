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

    // Use this for initialization
    void Start () {
        //navDestination = gameObject.transform;
    }

    public void UpdateDestination(Transform newDestination)
    {
        navDestination = newDestination;
    }
}
