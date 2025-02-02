using Unity.Mathematics;
using UnityEditor.PackageManager.UI;
using UnityEngine.WSA;

public class MoveInteractions
{

    public void HandleInteractions(MoveType p1Move, MoveType p2Move)
    {
        // This will handle when ever the move is the same, it will cancel out
        if (p1Move - p2Move == 0)
            NoEffect();
        /**************** Dodge *****************/
        if (p1Move == MoveType.Dodge || p2Move == MoveType.Dodge)
            NoEffect();

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
        }

        /**************** Throws *****************/
        if (p1Move == MoveType.Throw)
        {
            if(p2Move == MoveType.Block)
                Win();
            if(p2Move == MoveType.HardThrow)
                NoEffect();
            Lose();
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
        }

        /**************** Curse *****************/
        if (p1Move == MoveType.Curse)
        {
            if (p2Move == MoveType.Throw)
                Win();
            if (p2Move == MoveType.HardThrow)
                Win();

            HalfAndHalf();
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
        }

    }

    private void GetStun()
    {
        
    }
    private void NoEffect()
    {
        
    }

    private void Win()
    {
        
    }

    private void Lose()
    {
        
    }

    private void HalfAndHalf()
    {
        
    }
}
