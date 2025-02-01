using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tom : Character
{
    public Tom() : base(2,2,2,20)
    {
    }

    public override MoveData ExecuteHeavyUp()
    {
        MoveData m = new MoveData(MoveType.Curse, 4, 0);
        return m;
    }

    public override MoveData ExecuteHeavyForward()
    {
        MoveData m = new MoveData(MoveType.Projectile, 4, 0);
        return m;
    }

    public override MoveData ExecuteHeavyDown()
    {
        MoveData m = new MoveData(MoveType.Earthquake, 4, 0);
        return m;
    }
}





