using UnityEngine;
using TMPro;  // Required for TextMeshPro support

public class InputFieldHandler : MonoBehaviour
{
    public TMP_InputField inputField;

    public string ReadInput()
    {
        Debug.Log("Player Typed: " + inputField.text);
        return inputField.text;
    }
}
