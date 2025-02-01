using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMoscow : ICharacter
{
    // Start is called before the first frame update
    public int dodgeCooldown;
    public int highJumpCooldown;
    public int hardPunchCooldown;

    

    public MoveType ExecuteLightUp()
    {
        return MoveType.JumpAttack;
    }

    public MoveType ExecuteLightForward()
    {
        return MoveType.Punch;
    }

    public MoveType ExecuteLightDown()
    {
        return MoveType.Throw;
    }

    public MoveType ExecuteHeavyUp()
    {
        return MoveType.HighJump;
    }

    public MoveType ExecuteHeavyForward()
    {
        return MoveType.SuperPunch;
    }

    public MoveType ExecuteHeavyDown()
    {
        return MoveType.Dodge;
    }
}

