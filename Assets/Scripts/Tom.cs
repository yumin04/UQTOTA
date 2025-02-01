using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tom : Character
{
    public Tom() : base(2,2,2,20)
    {
    }
    public HP HealthPoints;

    public override MoveType ExecuteHeavyUp()
    {
        return MoveType.Curse;
    }

    public override MoveType ExecuteHeavyForward()
    {
        return MoveType.Projectile;
    }

    public override MoveType ExecuteHeavyDown()
    {
        return MoveType.Earthquake;
    }
}





