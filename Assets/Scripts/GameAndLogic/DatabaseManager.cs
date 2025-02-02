using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System;

[Serializable]
public class PlayerDatabaseInput
{
    public string username;
    public CharacterInfo characterInfo;
    public PlayerMoveKey playerMoveKey;
    public int moveNum;
}

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager Instance;
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    private string serverUrl = "http://your-python-server-ip:5000/";

    // Fetch player data and return it through a callback
    public void GetPlayer2UserInput(System.Action<PlayerDatabaseInput> callback)
    {
        StartCoroutine(RetrieveOpponentData(callback));
    }

    private IEnumerator RetrieveOpponentData(System.Action<PlayerDatabaseInput> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(serverUrl + "/get_data");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            PlayerDatabaseInput playerDatabaseInput = JsonUtility.FromJson<PlayerDatabaseInput>(json);
            callback?.Invoke(playerDatabaseInput);  // Pass data to callback
        }
        else
        {
            Debug.LogError("Error: " + request.error);
            callback?.Invoke(null);  // Handle failure case
        }
    }
    public void PostPlayer1Input(PlayerDatabaseInput player1Input)
    {
        StartCoroutine(SendPlayer1Input(player1Input));
    }

    // Coroutine to send the data as a POST request
    private IEnumerator SendPlayer1Input(PlayerDatabaseInput player1Input)
    {
        string jsonData = JsonUtility.ToJson(player1Input); // Convert the player1Input to JSON string
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData); // Convert JSON string to byte array

        UnityWebRequest request = new UnityWebRequest(serverUrl + "/post_player1_input", "POST");  // Adjust the endpoint as necessary
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Wait for the request to finish
        yield return request.SendWebRequest();
    }
}
