using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public InputFieldHandler inputField;
    private Player player1;
    private Player player2;
    private bool player2CharacterSelected;
    private bool player2UsernameSelected;
    private int moveNum;
    
    private DatabaseManager databaseManager;
    private PlayerDatabaseInput player2Data;
    public bool retrievedData;
    public bool player1SelectedMove;

    private MoveData player1MoveData;
    private MoveData player2MoveData;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        databaseManager = FindObjectOfType<DatabaseManager>();
        retrievedData = false;

    }
    void Start()
    {
        //TODO: retrieve all information from whatever we got in our main scene and post it to database. 
        player1 = new PlayerOne();
        PlayerDatabaseInput player1Input = new PlayerDatabaseInput
        {
            username = player1.GetUserName(),
            characterInfo = player1.GetCharacterInfo(), //TODO: make sure the character info is stored in CharacterSelect.cs 
            playerMoveKey = PlayerMoveKey.Block, //TODO: this will not matter in this case.
            moveNum = this.moveNum //this is super important that this stays as 0
        };
        databaseManager.PostPlayer1Input(player1Input);
        player2 = new PlayerTwo();
        databaseManager.GetPlayer2UserInput(OnDataReceivedForInformation);
    }

    void Update()
    {
        if (retrievedData)
        {
            retrievedData = false;
            //TODO make the scene go up
            //Start a Coroutine that will make it wait for the scene to finish
            //Under Coroutine
            //this coroutine waits for 10 seconds, always changeable
            StartCoroutine(GetUserInputs());
                //Get user input again
                //GetPlayer1Input
                //GetPlayer2Input
        }
    }

    private IEnumerator GetUserInputs()
    {
        yield return new WaitForSeconds(10);
        this.moveNum += 1;
        player1MoveData = player1.GetMoveData(PlayerMoveKey.Block);
        PlayerDatabaseInput player1Input = new PlayerDatabaseInput
        {
            username = player1.GetUserName(),
            characterInfo = player1.GetCharacterInfo(),  // Assuming characterInfo is an enum, this would be its integer value
            playerMoveKey = player1.GetUserInput(),  // Assuming playerMoveKey is an enum, this would be its integer value
            moveNum = this.moveNum
        };
        databaseManager.PostPlayer1Input(player1Input);
        // TODO: databaseManager.PostPlayer1Input()
        GetPlayer2Input();
    }
    private void OnDataReceivedForInformation(PlayerDatabaseInput data)
    {
        if (data != null)
        {
            player2.SetCharacter(data.characterInfo);
            player2.SetUserName(data.username);
            retrievedData = true;
            //Change scene so it will go to the fight scene
            databaseManager.GetPlayer2UserInput(OnDataReceivedForFight);
        }
        else
        {
            UnityEngine.Debug.LogError("Failed to retrieve Player 2 data.");
        }
    }
    private void OnDataReceivedForFight(PlayerDatabaseInput data)
    {
        if (data != null)
        {
            if (data.moveNum == this.moveNum)
            {
                retrievedData = true;
                player2MoveData = player2.GetMoveData(data.playerMoveKey);
            }
            else
            {
                StartCoroutine(DelayedPlayer2Input());
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Failed to retrieve Player 2 data.");
        }
    }
    IEnumerator DelayedPlayer2Input()
    {
        // TODO: get loading scene here
        yield return new WaitForSeconds(3);
        databaseManager.GetPlayer2UserInput(OnDataReceivedForFight);
    }

    public void GetPlayer2Input()
    {
        retrievedData = false;
        databaseManager.GetPlayer2UserInput(OnDataReceivedForFight);
    }
    
    //TODO: this function needs to go in UI class.
    public void OnClickEnterUsername()
    {
        player1.SetUserName(inputField.ReadInput());
    }
    
}
