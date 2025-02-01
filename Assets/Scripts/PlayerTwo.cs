using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : Player
{
    private string dataFromDatabase;
    private PlayerMoveKey currentInput;
    private Character character;
    public override void GetUserInput()
    {
    }

    public override void SetUserName(string userName)
    {
        base.SetUserName(userName);
    }

    private void GetDataFromDatabase()
    {
        
    }

    public override MoveData GetMoveData()
    {
        GetDataFromDatabase();
        return new MoveData();
    }

    public override void SetCharacter(CharacterInfo c)
    {
        
    }

    public override Character GetCharacter()
    {
        return character;
    }
}
