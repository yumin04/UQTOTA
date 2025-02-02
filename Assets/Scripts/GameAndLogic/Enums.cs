using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType

    {

        Projectile,
        Throw,
        JumpAttack,
        Block,
        Punch,
        Dodge,
        Leech,
        Curse,
        Earthquake,
        SuperPunch,
        HighJump,
        HardThrow,
        
    }
public struct MoveData
{
    public MoveType x;
    public int damage;
    public int enemyStunTime;
    public MoveData(MoveType x, int damage, int enemyStunTime)
    {
        this.x = x;
        this.damage = damage;
        this.enemyStunTime = enemyStunTime;
    }
}
public enum PlayerMoveKey
{
    LightForward,
    LightDown,
    LightUp,
    HeavyForward,
    HeavyDown,
    HeavyUp,
    Block
}

public enum CharacterInfo
{
    Jon,
    Tom,
    Sandie
}

public enum InteractionType
{
    Win,
    Lose,
    NoEffect,
    HalfAndHalf,
    Stun
}

