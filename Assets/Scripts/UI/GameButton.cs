using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour {
    private Button button;

    void Start() {
        button = GetComponent<Button>();
        
        // Ensure UIManager exists before binding
        if (UI.Instance != null) {
            button.onClick.AddListener(UI.Instance.OnClickGameInstantiate);
        } else {
            Debug.LogError("UIManager not found!");
        }
    }
}