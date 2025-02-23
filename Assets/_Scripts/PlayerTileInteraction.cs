using System;
using UnityEngine;

public class PlayerTileInteraction : MonoBehaviour
{
    public static int playerValue;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite[] numbers;
     void Start()
    {
        playerValue = 0;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Touching {collision.tag}");
        if(collision.CompareTag("Win Tile"))
        {
            // Player wins level
            if(playerValue == collision.GetComponent<Tile>().tileValue)
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

        // Plus
        else if (collision.CompareTag("Plus Tile"))
        {
            playerValue += collision.GetComponent<Tile>().tileValue;
            Debug.Log(playerValue);
            sr.sprite = numbers[Math.Abs(playerValue)];
        }

        // Sub
        else if (collision.CompareTag("Sub Tile"))
        {
            playerValue -= collision.GetComponent<Tile>().tileValue;
            Debug.Log(playerValue);
            sr.sprite = numbers[Math.Abs(playerValue)];
        }

        else if (collision.CompareTag("Mult Tile"))
        {
            playerValue *= collision.GetComponent<Tile>().tileValue;
        }

        else if (collision.CompareTag("Div Tile"))
        {
            playerValue /= collision.GetComponent<Tile>().tileValue;
        }
    }
}
