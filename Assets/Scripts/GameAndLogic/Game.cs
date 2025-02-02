using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game Instance;
    private UI ui;
    private Player player1;
    private Player player2;
    private bool player2CharacterSelected;
    private bool player2UsernameSelected;
    private int moveNum;
    
    private DatabaseManager databaseManager;
    private PlayerDatabaseInput player2Data;
    public bool retrievedData;
    public bool player1SelectedMove;
    public PlayerCharacterSpriteManager playerCharacterSpriteManager;

    private MoveData player1MoveData;
    private MoveData player2MoveData;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        retrievedData = false;
    }
    
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();
        playerCharacterSpriteManager = FindObjectOfType<PlayerCharacterSpriteManager>();
        ui = FindObjectOfType<UI>();
        player1 = new PlayerOne();
        player1.SetCharacter(ui.GetCharacterInfo());
        player1.SetUserName(ui.GetUserName());
        PlayerDatabaseInput player1Input = new PlayerDatabaseInput
        {
            username = ui.GetUserName(),
            characterInfo = ui.GetCharacterInfo(), //All done 
            playerMoveKey = PlayerMoveKey.Block, //This is a default value
            moveNum = this.moveNum //this is super important that this stays as 0
        };
        Debug.Log("" + player1Input.username + " " + player1Input.characterInfo + " " + player1Input.playerMoveKey);
        databaseManager.PostPlayer1Input(player1Input);
        Debug.Log("posted Player 1 input");
        player2 = new PlayerTwo();
        databaseManager.GetPlayer2UserInput(OnDataReceivedForInformation);
    }

    void Update()
    {
        if (retrievedData)
        {
            retrievedData = false;
            InteractionType playerInteraction = MoveInteractions.HandleInteractions(player1MoveData.x, player2MoveData.x);
            playerCharacterSpriteManager.SetPlayerSprites(player1.GetCharacterInfo(), player2.GetCharacterInfo());
            switch (playerInteraction)
            {
                case(InteractionType.Lose): 
                    playerCharacterSpriteManager.Lose();
                    break;
                case(InteractionType.Win):
                    playerCharacterSpriteManager.Win();
                    break;
                case(InteractionType.Stun):
                    playerCharacterSpriteManager.Stun();
                    break;
                case(InteractionType.HalfAndHalf):
                    playerCharacterSpriteManager.HalfAndHalf();
                    break;
                case(InteractionType.NoEffect):
                    playerCharacterSpriteManager.NoEffect();
                    break;
            }



            /*
             * Then set text box for the effect
             * characters changes sprite corresponding to that interaction
             * HP decreases based on interaction ex: player1.DecreaseHP( player1MoveData.damage)
             * 
             */
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
                player2MoveData = player2.GetMoveData(data.playerMoveKey);
                retrievedData = true;
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
    

    
}
