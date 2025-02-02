using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandie : Character
{
    public Sandie() : base(2,5,2,20)
    {
    }

    public override MoveData ExecuteHeavyUp()
    {
        MoveData m = new MoveData(MoveType.Leech, 4, 0);
        return m;
    }

    public override MoveData ExecuteHeavyForward()
    {
        MoveData m = new MoveData(MoveType.Projectile, 4, 0);
        return m;
    }

    public override MoveData ExecuteHeavyDown()
    {
        MoveData m = new MoveData(MoveType.HardThrow, 4, 0);
        return m;
    }

}