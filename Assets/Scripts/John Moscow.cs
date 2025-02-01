using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JohnMoscow : Character
{
    public JohnMoscow() : base(2,2,2,20)
    {
    }

    public override MoveData ExecuteHeavyUp()
    {
        MoveData m = new MoveData(MoveType.HighJump, 4, 0);
        return m;
    }

    public override MoveData ExecuteHeavyForward()
    {
        MoveData m = new MoveData(MoveType.SuperPunch, 4, 0);
        return m;
    }

    public override MoveData ExecuteHeavyDown()
    {
        MoveData m = new MoveData(MoveType.Dodge, 4, 0);
        return m;
    }
}

