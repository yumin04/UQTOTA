using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : Player
{
    private Character character;
    private PlayerMoveKey currentMove;
    private bool isReady;
    

    public override PlayerMoveKey GetUserInput()
    {
        return currentMove;
    }

    public PlayerMoveKey GetCurrentMove()
    {
        return currentMove;
    }

    public override MoveData GetMoveData(PlayerMoveKey m)
    {
        WaitUntilUserInputsKey();
        return base.GetMoveData(currentMove);
    }

    private void WaitUntilUserInputsKey()
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
    

}
