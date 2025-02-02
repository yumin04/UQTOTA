using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Required for TextMeshPro support

public class UI : MonoBehaviour
{
    public static UI Instance;
    //variables for username
    private string username;
    public InputFieldHandler inputField;
    public GameObject gameInstance;
    
    // variables for character input
    private CharacterInfo selectedCharacter;
    
    public Button infoButtonJon;
    public Button infoButtonSandie;
    public Button infoButtonTom;
    public PlayerOne playerOne;
    public TextMeshProUGUI characterDescriptionText;
   
    public string playerOneCharacter = null;
    public Text playerOneText;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    public void OnClickEnterUsername()
    {
        username = inputField.ReadInput();
    }

    //This will get selected character by button with parameter
    public void SelectCharacter(CharacterInfo characterName)
    {
        Debug.Log("SelectCharacter method called with: " + characterName);
        selectedCharacter = characterName;
        Debug.Log(selectedCharacter + ": selectedCharacter");
        playerOne.SetCharacter(selectedCharacter);
        
        if (infoButtonJon) infoButtonJon.interactable = (selectedCharacter == CharacterInfo.Jon);
        if (infoButtonSandie) infoButtonSandie.interactable = (selectedCharacter == CharacterInfo.Sandie);
        if (infoButtonTom) infoButtonTom.interactable = (selectedCharacter == CharacterInfo.Tom);
    }

    public string GetUserName()
    {
        return username;
    }

    public CharacterInfo GetCharacterInfo()
    {
        return selectedCharacter;
    }

    public void OnClickGameInstantiate()
    {
        Instantiate(gameInstance, transform.position, Quaternion.identity);
    }
    public void ShowCharacterInfo(string characterName)
    {
        string characterDescription = "";
        switch (selectedCharacter)
        {
            case CharacterInfo.Jon:
                characterDescription =
                    "Jon MoSCoW: Jon is your average cool movie star. He’s a white guy with brown hair slicked back. He wears sunglasses all the time, and likes to rock a leather jacket over a white shirt with jeans. He also wears black Converse/Vans-esque sneakers.";
                break;
            case CharacterInfo.Sandie:
                characterDescription =
                    "Sandie the Survivor: Sandie is a cyborg corgi. She has one red robot eye, and the area around that is made out of metal. Her front left leg and back right leg are robot legs. She also has a robot tail.";
                break;
            case CharacterInfo.Tom:
                characterDescription =
                    "Tom the Agile: Tom is a white guy with very short brown hair. He also has a mustache and a short beard that frames his face. He wears a sky blue wizard robe and wizard hat. The robe goes all the way to the floor. He also holds a staff made of wood that curves around a green gemstone at the top.";
                break;
            default:
                Debug.LogError("Invalud character name for description.");
                return;
        }

        if (characterDescriptionText)
        {
            characterDescriptionText.text = characterDescription;
        }
        
        Debug.Log("Character Info: " + characterDescription);
    }

}
