using Unity.Mathematics;
using UnityEditor.PackageManager.UI;
using UnityEngine.WSA;

public static class MoveInteractions
{
    private static InteractionType interactionType;
    public static InteractionType HandleInteractions(MoveType p1Move, MoveType p2Move)
    {
        // This will handle when ever the move is the same, it will cancel out
        if (p1Move - p2Move == 0)
        {
            NoEffect();
            return interactionType;
        }

        /**************** Dodge *****************/
        if (p1Move == MoveType.Dodge || p2Move == MoveType.Dodge)
        {
            NoEffect();
            return interactionType;
        }


        /**************** Projectiles *****************/
        if (p1Move == MoveType.Projectile)
        {
            if (p2Move == MoveType.Block)
                NoEffect();
            if (p2Move == MoveType.Dodge)
                NoEffect();
            if (p2Move == MoveType.Curse)
                HalfAndHalf();
            if (p2Move == MoveType.Earthquake)
                HalfAndHalf();
            Win();
            return interactionType;
        }

        /**************** Throws *****************/
        if (p1Move == MoveType.Throw)
        {
            if(p2Move == MoveType.Block)
                Win();
            if(p2Move == MoveType.HardThrow)
                NoEffect();
            Lose();
            return interactionType;
        }
        /**************** Jump *****************/
        if (p1Move == MoveType.JumpAttack)
        {
            if(p2Move == MoveType.Throw)
                Win();
            if (p2Move == MoveType.Punch)
                Win();
            if(p2Move == MoveType.Leech)
                Win();
            if(p2Move == MoveType.HardThrow)
                Win();
            if (p2Move == MoveType.Block)
                NoEffect();
            if (p2Move == MoveType.Curse)
                HalfAndHalf();
            if (p2Move == MoveType.Earthquake)
                HalfAndHalf();
            Lose();
            return interactionType;
        }

        /**************** Block *****************/
        if (p1Move == MoveType.Block)
        {
            if (p2Move == MoveType.Throw)
                Lose();
            if (p2Move == MoveType.Curse)
                Lose();
            if (p2Move == MoveType.HardThrow)
                Lose();
            if(p2Move == MoveType.Earthquake)
                HalfAndHalf();
            if (p2Move == MoveType.SuperPunch)
                GetStun();
            NoEffect();
            return interactionType;
        }

        /**************** Punch *****************/
        if (p1Move == MoveType.Punch)
        {
            if (p2Move == MoveType.Throw)
                Win();
            if (p2Move == MoveType.Leech)
                Win();
            if (p2Move == MoveType.Block)
                NoEffect();
            if (p2Move == MoveType.Curse)
                HalfAndHalf();
            if (p2Move == MoveType.Earthquake)
                HalfAndHalf();
            Lose();
            return interactionType;
        }

        /**************** Leech *****************/
        if (p1Move == MoveType.Leech)
        {
            if (p2Move == MoveType.Throw)
                Win();
            if (p2Move == MoveType.Block)
                Win();
            if (p2Move == MoveType.HardThrow)
                Win();
            if (p2Move == MoveType.Punch)
                HalfAndHalf();
            if (p2Move == MoveType.Curse)
                HalfAndHalf();
            if (p2Move == MoveType.Earthquake)
                HalfAndHalf();

            Lose();
            return interactionType;
        }

        /**************** Curse *****************/
        if (p1Move == MoveType.Curse)
        {
            if (p2Move == MoveType.Throw)
                Win();
            if (p2Move == MoveType.HardThrow)
                Win();

            HalfAndHalf();
            return interactionType;
        }

        /**************** Earthquake *****************/
        if (p1Move == MoveType.Earthquake)
        {
            if (p2Move == MoveType.Throw)
                Win();
            if (p2Move == MoveType.JumpAttack)
                Lose();
            if (p2Move == MoveType.HighJump)
                Lose();
            HalfAndHalf();
            return interactionType;
        }
        /**************** SuperPunch *****************/
        if (p1Move == MoveType.SuperPunch)
        {
            if (p2Move == MoveType.Throw)
                Win();
            if (p2Move == MoveType.JumpAttack)
                Lose();
            if (p2Move == MoveType.HighJump)
                Lose();
            HalfAndHalf();
            return interactionType;
        }
        /**************** HighJump *****************/
        if (p1Move == MoveType.HighJump)
        {
            if (p2Move == MoveType.Projectile)
                Lose();
            if (p2Move == MoveType.SuperPunch)
                Lose();
            if (p2Move == MoveType.Block)
                NoEffect();
            if (p2Move == MoveType.Curse)
                HalfAndHalf();
            Win();
            return interactionType;
        }
        /**************** HardThrow *****************/
        if (p1Move == MoveType.HighJump)
        {
            if (p2Move == MoveType.Block)
                Win();
            if (p2Move == MoveType.Punch)
                Win();
            if (p2Move == MoveType.Earthquake)
                Win();
            if (p2Move == MoveType.Throw)
                NoEffect();
            Lose();
            return interactionType;
        }

        return interactionType;
    }

    private static void GetStun()
    {
        interactionType = InteractionType.Stun;
    }
    private static void NoEffect()
    {
        interactionType = InteractionType.NoEffect;
    }

    private static void Win()
    {
        interactionType = InteractionType.Win;
    }

    private static void Lose()
    {
        interactionType = InteractionType.Lose;
    }

    private static void HalfAndHalf()
    {
        interactionType = InteractionType.HalfAndHalf;
    }
}
