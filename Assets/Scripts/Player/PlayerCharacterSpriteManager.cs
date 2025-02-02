using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterSpriteManager : MonoBehaviour
{
    
    public GameObject Player1Sprite;
    public GameObject Player2Sprite;
    public Text ResultsText;
    private SpriteRenderer p1SpriteRenderer;
    private SpriteRenderer p2SpriteRenderer;
    public Sprite[] characterSprites;

    public void Start()
    {
        p1SpriteRenderer = Player1Sprite.GetComponent<SpriteRenderer>();
        p2SpriteRenderer = Player2Sprite.GetComponent<SpriteRenderer>();

    }
    public void Lose()
    {
        ResultsText.text = "You Lost";
    }

    public void Win()
    {
        ResultsText.text = "You Won";
    }

    public void NoEffect()
    {
        ResultsText.text = "No Effect";
    }

    public void HalfAndHalf()
    {
        ResultsText.text = "Both take damage";
    }

    public void Stun()
    {
        ResultsText.text = "You are stunned";
    }

    public void SetPlayerSprites(CharacterInfo player1, CharacterInfo player2)
    {
        switch (player1)
        {
            case CharacterInfo.Jon:
                p1SpriteRenderer.sprite = characterSprites[0];
                break;
            case CharacterInfo.Tom:
                p1SpriteRenderer.sprite = characterSprites[0];
                break;
            case CharacterInfo.Sandie:
                p1SpriteRenderer.sprite = characterSprites[0];
                break;
        }

        switch (player2)
        {
            case CharacterInfo.Jon:
                p2SpriteRenderer.sprite = characterSprites[0];
                break;
            case CharacterInfo.Tom:
                p2SpriteRenderer.sprite = characterSprites[0];
                break;
            case CharacterInfo.Sandie:
                p2SpriteRenderer.sprite = characterSprites[0];
                break;
        }
    }
    
}