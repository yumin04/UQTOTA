using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System;
using System.Collections.Generic;
[Serializable]
public class PlayerDatabaseInput
{
    public string username;
    public CharacterInfo character_info;
    public PlayerMoveKey player_move;
    public int turn_number;
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
    private string serverUrl = "http://10.208.168.48:5000/";

    // Fetch player data and return it through a callback
    public void GetPlayer2UserInput(System.Action<PlayerDatabaseInput> callback)
    {
        StartCoroutine(RetrieveOpponentData(callback));
    }
    // json = json.Substring(1, json.Length - 2); // Removing the outer []

    // Split the string by "],[" to get each inner array
    // string[] elements = json.Split(new string[] { "],[" }, StringSplitOptions.None);

    private IEnumerator RetrieveOpponentData(System.Action<PlayerDatabaseInput> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(serverUrl + "/get_game_data");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            Debug.Log("Raw JSON: " + json);

            // Manually parse array
            json = json.Trim('[', ']');  // Remove outer brackets
            string[] elements = json.Split(new string[] { "],[" }, StringSplitOptions.None);
            List<PlayerDatabaseInput> playerList = new List<PlayerDatabaseInput>();

            foreach (string element in elements)
            {
                string[] parts = element.Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');

                if (parts.Length == 4)
                {
                    PlayerDatabaseInput player = new PlayerDatabaseInput
                    {
                        username = parts[0],
                        character_info = (CharacterInfo)int.Parse(parts[1]),
                        player_move = (PlayerMoveKey)int.Parse(parts[2]),
                        turn_number = int.Parse(parts[3])
                    };
                    playerList.Add(player);
                }
            }
            if(Game.Instance.player1.GetUserName() == playerList[0].username)
                callback?.Invoke(playerList[1]);
            callback?.Invoke(playerList[0]);

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

        UnityWebRequest request = new UnityWebRequest(serverUrl + "/update_move_data_route", "POST");  // Adjust the endpoint as necessary
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Wait for the request to finish
        yield return request.SendWebRequest();

    }
}
