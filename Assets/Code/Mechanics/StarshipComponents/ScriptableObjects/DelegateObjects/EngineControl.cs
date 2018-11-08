using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineControl : ScriptableObject {

    // Use this for initialization
    public void ApplyEngineThrust(StarshipController starship)
    {
        starship.AccelerateStarship();
    }
}
