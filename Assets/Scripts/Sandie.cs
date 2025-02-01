using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandie : ICharacter, MonoBehaviour
{
    // Start is called before the first frame update
    public int laserCooldown;
    public int leechCooldown;
    public int heavyThrowCooldown;

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
        return MoveType.Leech;
    }

    public MoveType ExecuteHeavyForward()
    {
        return MoveType.Projectile;
    }

    public MoveType ExecuteHeavyDown()
    {
        return MoveType.HardThrow;
    }

}