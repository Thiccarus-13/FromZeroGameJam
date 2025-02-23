using UnityEngine;

public class HoleInteraction : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (GameManager.levelsWon)
        {
            case 0:
                player[0].transform.position = spawnPoints[0].transform.position;
                player[1].transform.position = spawnPoints[0].transform.position;
                break;
            case 1:
                player[0].transform.position = spawnPoints[1].transform.position;
                player[1].transform.position = spawnPoints[1].transform.position;
                break;
            case 2:
                player[0].transform.position = spawnPoints[2].transform.position;
                player[1].transform.position = spawnPoints[2].transform.position;
                break;
        }
    }
}
