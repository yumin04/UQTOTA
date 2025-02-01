using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Player player1;
    private Player player2;
    // Update is called once per frame
    void Update()
    {
        player1.GetUserInput();
        player2.GetUserInput();
    }
}
