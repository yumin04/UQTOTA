using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour {
    private Button button;
    [SerializeField]
    public CharacterInfo characterInfo;

    void Start() {
        button = GetComponent<Button>();
        
        // Ensure UIManager exists before binding
        if (UI.Instance != null) {
            button.onClick.AddListener(() => UI.Instance.SelectCharacter(characterInfo));
        } else {
            Debug.LogError("UIManager not found!");
        }
    }
}