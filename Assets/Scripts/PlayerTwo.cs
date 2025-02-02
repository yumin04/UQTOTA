using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : Player
{
    private string dataFromDatabase;
    private PlayerMoveKey currentInput;
    private DatabaseManager databaseManager;
    private PlayerDatabaseInput player2Data;
    public bool retrievedData;
    
    public override PlayerMoveKey GetUserInput()
    {
        return PlayerMoveKey.HeavyDown;
    }

    public override void SetUserName(string userName)
    {
        base.SetUserName(player2Data.username);
    }

    public bool GetRetrievedData()
    {
        return retrievedData;
    }
    // Callback function when data is received
    
    
}
