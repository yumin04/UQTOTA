using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JohnMoscow : Character
{
    public JohnMoscow() : base(2,2,2,20)
    {
    }

    public override MoveType ExecuteHeavyUp()
    {
        return MoveType.HighJump;
    }

    public override MoveType ExecuteHeavyForward()
    {
        return MoveType.SuperPunch;
    }

    public override MoveType ExecuteHeavyDown()
    {
        return MoveType.Dodge;
    }
}

