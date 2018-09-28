using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlaster : MonoBehaviour
{
    public KeyCode fireBoltKey;
    public LaserBolt laserBoltPrefab;
    public Transform firePoint;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireBoltKey))
        {
            Instantiate(laserBoltPrefab, firePoint);
        }
    }
}