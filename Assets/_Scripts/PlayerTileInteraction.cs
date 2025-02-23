using System;
using UnityEngine;

public class PlayerTileInteraction : MonoBehaviour
{
    public static int playerValue;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite[] posNumbers;
    [SerializeField] private Sprite[] negNumbers;
    [SerializeField] private Sprite zero;
    void Start()
    {
        playerValue = 0;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Touching {collision.tag}");
        if (collision.CompareTag("Win Tile"))
        {
            // Player wins level
            if (playerValue == collision.GetComponent<Tile>().tileValue)
            {
                Debug.Log("Player wins!");
                GameManager.levelsWon++;
                playerValue = 0;
            }
            else
            {
                Debug.Log("Player doesn't win");
            }
        }

        else if (collision.CompareTag("Plus Tile"))
        {
            playerValue += collision.GetComponent<Tile>().tileValue;
            UpdateSprite();
        }

        else if (collision.CompareTag("Sub Tile"))
        {
            playerValue -= collision.GetComponent<Tile>().tileValue;
            UpdateSprite();
        }

        else if (collision.CompareTag("Mult Tile"))
        {
            playerValue *= collision.GetComponent<Tile>().tileValue;
            UpdateSprite();
        }

        else if (collision.CompareTag("Div Tile"))
        {
            playerValue /= collision.GetComponent<Tile>().tileValue;
            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        if (playerValue > 0 && playerValue < 10)
        {
            sr.sprite = posNumbers[playerValue - 1];
        }
        else if (playerValue < 0 && playerValue > -10)
        {
            sr.sprite = negNumbers[Math.Abs(playerValue) - 1];
        }
        else
        {
            sr.sprite = zero;
        }
    }
}
