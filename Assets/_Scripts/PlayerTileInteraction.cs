using System;
using UnityEngine;

public class PlayerTileInteraction : MonoBehaviour
{
    public static int playerValue;  
    [SerializeField] private Sprite[] posNumbers;
    [SerializeField] private Sprite[] negNumbers;
    [SerializeField] private Sprite zero;
    [SerializeField] private PlayerChildSprite sprite1;
    [SerializeField] private PlayerChildSprite sprite2;


    void Start()
    {
        playerValue = 0;
        UpdateSprite();
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
        Debug.Log("Updating Sprite");
        if (playerValue > 0 && playerValue < 10)
        {
            sprite1.sr.sprite = posNumbers[playerValue - 1];
            sprite1.setDisplayMode("Single");
            sprite2.setDisplayMode("None");

            sprite1.transform.localPosition = Vector3.zero;
        }
        else if (playerValue < 0 && playerValue > -10)
        {
            sprite1.sr.sprite = negNumbers[Math.Abs(playerValue - 1)];
            sprite1.setDisplayMode("Single");
            sprite2.setDisplayMode("None");
            sprite1.transform.localPosition = Vector3.zero;
        }
        else if (playerValue > 10)
        {
            int rightDigit = playerValue;
            while (rightDigit >= 10) {rightDigit -= 10;}
            int leftDigit = playerValue - rightDigit;
            leftDigit /= 10;


            sprite1.sr.sprite = posNumbers[leftDigit - 1];
            sprite1.setDisplayMode("Double");
            sprite2.sr.sprite = posNumbers[rightDigit - 1];
            sprite2.setDisplayMode("Double");

            sprite1.transform.localPosition = transform.localPosition;
            // This puts sprite2 next to sprite1. 
            sprite2.transform.localPosition = new Vector3(sprite1.GetComponent<SpriteRenderer>().bounds.size.x, 0f, 0f);
        }
        else if (playerValue < -10)
        {
            int rightDigit = playerValue;
            while (rightDigit <= -10){rightDigit += 10;}
            int leftDigit = playerValue - rightDigit;
            leftDigit /= 10;


            sprite1.sr.sprite = negNumbers[Math.Abs(leftDigit) - 1];
            sprite1.setDisplayMode("Double");
            sprite2.sr.sprite = negNumbers[Math.Abs(rightDigit) - 1];
            sprite2.setDisplayMode("Double");
            sprite1.transform.localPosition = transform.localPosition;
            // This puts sprite2 next to sprite1. 
            sprite2.transform.localPosition = new Vector3(sprite1.GetComponent<SpriteRenderer>().bounds.size.x, 0f, 0f);
        }
        else
        {
            sprite1.sr.sprite = zero;
            sprite1.setDisplayMode("Single");
            sprite2.setDisplayMode("None");
        }
    }

    public void setPlayerValue(int newVal){
        playerValue = newVal;
        UpdateSprite();
    }
}
