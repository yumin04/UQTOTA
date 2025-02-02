using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour 
{
    
    public string playerOneCharacter = null;
    public Text playerOneText;
    private PlayerOne playerOne;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Character Select Initialized. Current selection: " + playerOneCharacter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharacter(string characterName)
    {
        Debug.Log("SelectCharacter method called with: " + characterName);
        
        if (playerOneCharacter == null)
        {
            // playerOneCharacter = characterName;
            // Debug.LogError("Player One reference is missing!");
            return;
        }

        CharacterInfo selectedCharacter = CharacterInfo.Jon;

        switch (characterName)
        {
            case "Jon":
                selectedCharacter = CharacterInfo.Jon;
                break;
            case "Sandie":
                selectedCharacter = CharacterInfo.Sandie;
                break;
            case "Tom":
                selectedCharacter = CharacterInfo.Tom;
                break;
            default:
                // Debug.LogError("Invalid character name: " + characterName);
                break;
        }

        if (playerOne != null) playerOne.SetCharacter(selectedCharacter);

        if (playerOneText != null)
        {
            playerOneText.text = "Player One Selected:" + selectedCharacter.ToString();
        }

        // Debug.Log("Player One Selected: " + selectedCharacter);

    }
    
    // public void TestButtonPress()
    // {
    //     Debug.Log("Button Pressed!");
    // }


        // bool JonButton()
        // {
        //     if (PlayerOne || PlayerTwo == JonButton.OnClick.AddListener(OnButtonClick))
        //     {
        //         Character.Jon = true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }
}
