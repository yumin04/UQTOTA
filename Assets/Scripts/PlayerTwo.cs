using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : Player
{
    private string dataFromDatabase;
    public override PlayerMoveKey? GetUserInput()
    {
        return PlayerMoveKey.Block;
    }

    public override void SetUserName(string userName)
    {
        base.SetUserName(userName);
    }

    private void GetDataFromDatabase()
    {
        
    }

}
