using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipEventArgs : EventArgs
{
    public StarshipEventArgs(StarshipController sc)
    {
        sc = StarshipController;
    }
    public StarshipController StarshipController { get; }
}
