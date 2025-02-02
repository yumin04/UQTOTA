using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public Cooldown HeavyUpCooldown = new Cooldown();
    public Cooldown HeavyForwardCooldown = new Cooldown();
    public Cooldown HeavyDownCooldown = new Cooldown();
    public HP HealthPoints = new HP();

    public Character(int heavyUpCooldown, int heavyForwardCooldown, int heavyDownCooldown, int healthPoint)
    {
        HeavyUpCooldown.SetCooldown(heavyUpCooldown);
        HeavyForwardCooldown.SetCooldown(heavyForwardCooldown);
        HeavyDownCooldown.SetCooldown(heavyDownCooldown);
        HealthPoints.SetHP(healthPoint);
    }
    
    public MoveData ExecuteLightUp()
    {
        MoveData m = new MoveData(MoveType.JumpAttack, 4, 0);
        return m;
    }

    public MoveData ExecuteLightForward()
    {
        MoveData m = new MoveData(MoveType.Punch, 4, 0);
        return m;
    }

    public MoveData ExecuteLightDown()
    {
        MoveData m = new MoveData(MoveType.Throw, 4, 0);
        return m;
    }

    public MoveData ExecuteBlock()
    {
        MoveData m = new MoveData(MoveType.Block, 0, 0);
        return m;
    }

    public abstract MoveData ExecuteHeavyUp();

    public abstract MoveData ExecuteHeavyForward();


    public abstract MoveData ExecuteHeavyDown();

}
