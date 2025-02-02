using UnityEngine;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour {
    public Button button;
    public string sceneName;

    void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => SceneHandler.Instance.LoadScene(sceneName));
    }
}