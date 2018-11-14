using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipSpawnController : MonoBehaviour
{
    public KeyCode debugSpawnFighter;
    public KeyCode debugSpawnMiner;
    public Transform spawnPoint;
    public CapitalStarship capitolShip;
    public NPCController fighterNpc;
    public NPCController minerNpc;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(debugSpawnFighter))
        {
            SpawnFighterStarship();
        }
        if (Input.GetKeyDown(debugSpawnMiner))
        {
            SpawnMinerStarship();
        }
    }
    public void SpawnFighterStarship()
    {

        Instantiate(fighterNpc, spawnPoint);
    }
    public void SpawnMinerStarship()
    {
        minerNpc.CapitalStarship = capitolShip;
        minerNpc.Faction = capitolShip.Faction;
        minerNpc.transform.parent = null;
        Instantiate(minerNpc, spawnPoint);
    }
}
