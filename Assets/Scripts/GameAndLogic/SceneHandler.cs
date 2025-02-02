using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
    public static SceneHandler Instance;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadStartScene() {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadCharacterSelect() {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void LoadFightScene() {
        SceneManager.LoadScene("FightScene");
    }
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    
}