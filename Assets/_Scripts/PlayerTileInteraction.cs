using UnityEngine;

public class PlayerTileInteraction : MonoBehaviour
{
    public static int playerValue;
     void Start()
    {
        playerValue = 0;
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
        }

        // Sub
        else if (collision.CompareTag("Sub Tile"))
        {
            playerValue -= collision.GetComponent<Tile>().tileValue;
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
