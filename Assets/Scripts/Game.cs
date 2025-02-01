using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] public InputFieldHandler inputField;
    [SerializeField] private Player player1;
    private Player player2;

    private MoveData player1MoveData;
    private MoveData player2MoveData;

    void Start()
    {
        player1 = new PlayerOne();
        player2 = new PlayerTwo();
        // player1.SetCharacter(CharacterInfo.Jon);
        // player2.SetCharacter(CharacterInfo.Jon);
    }
    //void Update()
    //{
    //    player1MoveData = player1.GetMoveData();
    //    player2MoveData = player2.GetMoveData();
    //}

    public void OnClickEnterUsername()
    {
        player1.SetUserName(inputField.ReadInput());
    }
}
