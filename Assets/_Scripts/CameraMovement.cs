using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform[] cameraPoints;

    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerMovePoint;
    [SerializeField] private GameObject[] playerSpawns;

    private bool onLevel1 = false;
    private bool onLevel2 = false;
    [SerializeField] private Sprite[] numbers;


    /// <summary>
    ///  Controls which level the player is currently on
    /// </summary>
    void Update()
    {
        switch (GameManager.levelsWon)
        {
            case 1:
                if (onLevel1 == false)
                {
                    player.transform.position = playerSpawns[0].transform.position;
                    playerMovePoint.transform.position = playerSpawns[0].transform.position;
                    transform.position = cameraPoints[0].position;
                    onLevel1 = true;

                    player.GetComponent<SpriteRenderer>().sprite = numbers[Math.Abs(PlayerTileInteraction.playerValue)];
                }
                break;
            case 2:
                if (onLevel2 == false)
                {
                    player.transform.position = playerSpawns[1].transform.position;
                    playerMovePoint.transform.position = playerSpawns[1].transform.position;
                    transform.position = cameraPoints[1].position;
                    onLevel2 = true;
                    player.GetComponent<SpriteRenderer>().sprite = numbers[Math.Abs(PlayerTileInteraction.playerValue)];

                }
                break;

            // TODO - Add more levels later
            case 3:
                SceneManager.LoadScene("Game Over");
                break;
        }
    }
}
