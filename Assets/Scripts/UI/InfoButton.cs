using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour {
    private Button button;
    public CharacterInfo characterName;
    void Start() {
        button = GetComponent<Button>();
        // Ensure UIManager exists before binding
        if (UI.Instance != null) {
            button.onClick.AddListener(() => UI.Instance.ShowCharacterInfo());
        } else {
            Debug.LogError("UIManager not found!");
        }
    }

    void Update()
    {
        if (UI.Instance.GetCharacterInfo() == characterName)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}