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
}
