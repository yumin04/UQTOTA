using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : Player
{
    private Character character;
    private MoveType currentMove;
    private bool isReady;

    void Update()
    {
        GetUserInput();
    }
    public override void GetUserInput()
    {
        if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentMove = character.ExecuteLightForward();
            isReady = true;
        } else if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentMove = character.ExecuteLightDown();
            isReady = true;
        } else if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentMove = character.ExecuteLightUp();
            isReady = true;
        } else if (Input.GetKeyDown(KeyCode.H) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentMove = character.ExecuteHeavyForward();
            isReady = true;
        } else if (Input.GetKeyDown(KeyCode.H) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentMove = character.ExecuteHeavyDown();
            isReady = true;
        } else if (Input.GetKeyDown(KeyCode.H) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentMove = character.ExecuteHeavyUp();
            isReady = true;
        } else if (Input.GetKeyDown(KeyCode.B))
        {
            currentMove = character.ExecuteBlock();
            isReady = true;
        } 
    }

    public MoveType GetCurrentMove()
    {
        return currentMove;
    }
}
