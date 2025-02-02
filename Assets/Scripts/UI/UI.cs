using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Required for TextMeshPro support

public class UI : MonoBehaviour
{
    //variables for username
    public string username;
    public InputFieldHandler inputField;
    
    // variables for character input
    public string playerOneCharacter = null;
    public Text playerOneText;
    private CharacterInfo selectedCharacter;
    public void OnClickEnterUsername()
    {
        username = inputField.ReadInput();
    }

    //This will get selected character by button with parameter
    public void SelectCharacter(string characterName)
    {
        Debug.Log("SelectCharacter method called with: " + characterName);
        
        if (playerOneCharacter == null)
        {
            // playerOneCharacter = characterName;
            // Debug.LogError("Player One reference is missing!");
            return;
        }

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
                break;
        }

        if (playerOneText != null)
        {
            playerOneText.text = "Player One Selected:" + selectedCharacter.ToString();
        }

    }

    public string GetUserName()
    {
        return username;
    }

    public CharacterInfo GetCharacterInfo()
    {
        return selectedCharacter;
    }

    public void OnClickMoveNextButton()
    {
        // next button that will go from character select to fight scene
        //This will instantiate game class as an object
        
    }
}
