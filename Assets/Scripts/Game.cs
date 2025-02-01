using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Player player1;
    private Player player2;

    private PlayerMoveKey? player1Input;
    private PlayerMoveKey? player2Input;
    // Update is called once per frame
    void Update()
    {
        player1Input = player1.GetUserInput();
        player2Input = player2.GetUserInput();
    }
}
