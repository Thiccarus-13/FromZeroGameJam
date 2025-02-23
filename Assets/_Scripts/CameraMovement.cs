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

    private bool[] levelsWon = new bool[20];
    [SerializeField] private Sprite zeroSprite;


    /// <summary>
    ///  Controls which level the player is currently on
    /// </summary>
    void Update()
    {
        // Debug.Log(GameManager.levelsWon);
        switch (GameManager.levelsWon)
        {
            case 1:
                if (levelsWon[0] == false)
                {
                    SetPlayerCameraSpawn(0);
                }
                break;
            case 2:
                if (levelsWon[1] == false)
                {
                    SetPlayerCameraSpawn(1);
                }
                break;
            case 3:
                if (levelsWon[2] == false)
                {
                    SetPlayerCameraSpawn(2);
                }
                break;
            case 4:
                if (levelsWon[3] == false)
                {
                    SetPlayerCameraSpawn(3);
                }
                break;
            case 5:
                if (levelsWon[4] == false)
                {
                    SetPlayerCameraSpawn(4);
                }
                break;
            case 6:
                if (levelsWon[5] == false)
                {
                    SetPlayerCameraSpawn(5);
                }
                break;
            case 7:
                if (levelsWon[6] == false)
                {
                    SetPlayerCameraSpawn(6);
                }
                break;
            case 8:
                if (levelsWon[7] == false)
                {
                    SetPlayerCameraSpawn(7);
                }
                break;
            case 9:
                if (levelsWon[8] == false)
                {
                    SetPlayerCameraSpawn(8);
                }
                break;
            case 10:
                if (levelsWon[9] == false)
                {
                    SetPlayerCameraSpawn(9);
                }
                break;
            case 11:
                if (levelsWon[10] == false)
                {
                    SetPlayerCameraSpawn(10);
                }
                break;
            case 12:
                if (levelsWon[11] == false)
                {
                    SetPlayerCameraSpawn(11);
                }
                break;
            case 13:
                if (levelsWon[12] == false)
                {
                    SetPlayerCameraSpawn(12);
                }
                break;
            case 14:
                if (levelsWon[13] == false)
                {
                    SetPlayerCameraSpawn(13);
                }
                break;
            case 15:
                if (levelsWon[14] == false)
                {
                    SetPlayerCameraSpawn(14);
                }
                break;
            case 16:
                if (levelsWon[15] == false)
                {
                    SetPlayerCameraSpawn(15);
                }
                break;
            case 17:
                if (levelsWon[16] == false)
                {
                    SetPlayerCameraSpawn(16);
                }
                break;
            case 18:
                if (levelsWon[17] == false)
                {
                    SetPlayerCameraSpawn(17);
                }
                break;

            // TODO - Add more levels later
            case 19:
                SceneManager.LoadScene("Game Over");
                break;
        }
    }

    private void SetPlayerCameraSpawn(int newPoint)
    {
        player.transform.position = playerSpawns[newPoint].transform.position;
        playerMovePoint.transform.position = playerSpawns[newPoint].transform.position;
        transform.position = cameraPoints[newPoint].position;
        levelsWon[newPoint] = true;
        player.GetComponent<SpriteRenderer>().sprite = zeroSprite;
    }
}
