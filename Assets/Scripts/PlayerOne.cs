using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : Player
{
    private Character character;
    private PlayerMoveKey currentMove;
    private bool isReady;

    public override void SetCharacter(CharacterInfo c)
    {
        switch (c)
        {
            case CharacterInfo.Jon: { 
                this.character = new JohnMoscow();
                break;
            }
            case CharacterInfo.Sandie:
            {
                this.character = new Sandie();
                break;
            }
            case CharacterInfo.Tom:
                this.character = new Tom();
                break;
        }
    }

    public override void GetUserInput()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentMove = PlayerMoveKey.LightForward;
                break;
            }
            if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentMove = PlayerMoveKey.LightDown;
                break;
            }
            if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentMove = PlayerMoveKey.LightUp;
                break;
            }

            if (Input.GetKeyDown(KeyCode.H) && Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentMove = PlayerMoveKey.HeavyForward;
                break;
            }

            if (Input.GetKeyDown(KeyCode.H) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentMove = PlayerMoveKey.HeavyDown;
                break;
            }

            if (Input.GetKeyDown(KeyCode.H) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentMove = PlayerMoveKey.HeavyUp;
                break;
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                currentMove = PlayerMoveKey.Block;
                break;
            }    
        }
    }

    public PlayerMoveKey GetCurrentMove()
    {
        return currentMove;
    }

    public override MoveData GetMoveData()
    {
        GetUserInput();
        switch (currentMove)
        {
            case(PlayerMoveKey.LightForward): return character.ExecuteLightForward();
            case(PlayerMoveKey.LightDown): return character.ExecuteLightDown();
            case(PlayerMoveKey.LightUp): return character.ExecuteLightUp();
            case(PlayerMoveKey.HeavyForward): return character.ExecuteHeavyForward();
            case(PlayerMoveKey.HeavyDown): return character.ExecuteHeavyDown();
            case(PlayerMoveKey.HeavyUp): return character.ExecuteHeavyUp();
            case(PlayerMoveKey.Block): return character.ExecuteBlock();
        }

        return new MoveData();
    }

    public override Character GetCharacter()
    {
        return character;
    }
}
