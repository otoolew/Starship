using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchException : BaseException
{
    public readonly ActorController attacker;
    public readonly ActorController target;

    public MatchException(ActorController attacker, ActorController target) : base(false)
    {
        this.attacker = attacker;
        this.target = target;
    }
}
