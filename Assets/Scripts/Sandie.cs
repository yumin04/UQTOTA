using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandie : Character
{
    public Sandie() : base(2,2,2,20)
    {
    }

    public override MoveType ExecuteHeavyUp()
    {
        return MoveType.Leech;
    }

    public override MoveType ExecuteHeavyForward()
    {
        return MoveType.Projectile;
    }

    public override MoveType ExecuteHeavyDown()
    {
        return MoveType.HardThrow;
    }

}