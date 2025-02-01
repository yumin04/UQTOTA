using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character: MonoBehaviour
{
    public Cooldown HeavyUpCooldown;
    public Cooldown HeavyForwardCooldown;
    public Cooldown HeavyDownCooldown;
    public HP HealthPoints;

    public Character(int heavyUpCooldown, int heavyForwardCooldown, int heavyDownCooldown, int healthPoint)
    {
        HeavyUpCooldown.SetCooldown(heavyUpCooldown);
        HeavyForwardCooldown.SetCooldown(heavyForwardCooldown);
        HeavyDownCooldown.SetCooldown(heavyDownCooldown);
        HealthPoints.SetHP(healthPoint);
    }
    
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

    public MoveType ExecuteBlock()
    {
        return MoveType.Block;
    }

    public abstract MoveType ExecuteHeavyUp();

    public abstract MoveType ExecuteHeavyForward();


    public abstract MoveType ExecuteHeavyDown();

}
