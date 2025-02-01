using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tom : Character
{
    // Start is called before the first frame update
    public int curseCooldown;
    public int earthquakeCooldown;
    public int spellCooldown;

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
        return MoveType.Curse;
    }

    public MoveType ExecuteHeavyForward()
    {
        return MoveType.Projectile;
    }

    public MoveType ExecuteHeavyDown()
    {
        return MoveType.Earthquake;
    }
}





