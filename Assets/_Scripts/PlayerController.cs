using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5; // speed of player
    [SerializeField] private Transform movePoint; // Point player moves to 


    private readonly float movePointDistance = 0.05f;

    /// <summary>
    ///  Moves player 1 "tile" forward in cardinal directions.
    ///  
    ///  Player cannot change direction until releasing currently held movement key. 
    /// </summary>
    void Update()
    {

        this.gameObject.transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= movePointDistance)
        {
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            float verticalMove = Input.GetAxisRaw("Vertical");
            if (Math.Abs(horizontalMove) == 1)
            {
                Vector3 normalHoriz = new(horizontalMove, 0f, 0f);
                normalHoriz.Normalize();
                movePoint.position += normalHoriz;
            }

            else if (Math.Abs(verticalMove) == 1)
            {
                Vector3 normalVert = new(0f, verticalMove, 0f);
                normalVert.Normalize();
                movePoint.position += normalVert;
            }
        }
    }
}
