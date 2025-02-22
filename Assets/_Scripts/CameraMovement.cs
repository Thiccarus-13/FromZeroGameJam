using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform[] cameraPoints;

    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerMovePoint;
    [SerializeField] private GameObject[] playerSpawns;

    private bool onLevel1 = false;
    private bool onLevel2 = false;

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
                }
                break;
            case 2:
                if (onLevel2 == false)
                {
                    player.transform.position = playerSpawns[1].transform.position;
                    playerMovePoint.transform.position = playerSpawns[1].transform.position;
                    transform.position = cameraPoints[1].position;
                    onLevel2 = true;
                }
                break;
        }
    }
}
