using System;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] player;
    [SerializeField] private Sprite defaultSprite;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerTileInteraction.playerValue = 0;
            MovePlayer(GameManager.levelsWon);
            ResetPlayerSprite();
        }
    }

    private void ResetPlayerSprite()
    {
        player[0].GetComponent<SpriteRenderer>().sprite = defaultSprite;
        player[0].GetComponent<PlayerTileInteraction>().setPlayerValue(0);
    }

    private void MovePlayer(int position)
    {
        player[0].transform.position = spawnPoints[position].transform.position;
        player[1].transform.position = spawnPoints[position].transform.position;
    }
}
