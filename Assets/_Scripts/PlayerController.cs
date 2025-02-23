using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5; // speed of player
    [SerializeField] private Transform movePoint; // Point player moves to 
    [SerializeField] private LayerMask obstacleMask;


    private readonly float movePointDistance = 0.05f;

    private Vector3 currentPosition;

    private void Start()
    {
        currentPosition = transform.position;
    }


    /// <summary>
    ///  Moves player 1 "tile" forward in cardinal directions.
    ///  
    ///  Player cannot change direction until releasing currently held movement key. 
    /// </summary>
    void Update()
    {
        currentPosition = transform.position;
        this.gameObject.transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= movePointDistance)
        {
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            float verticalMove = Input.GetAxisRaw("Vertical");
            if (Math.Abs(horizontalMove) == 1)
            {

                Vector3 normalHoriz = new(horizontalMove, 0f, 0f);
                if (!Physics2D.OverlapCircle(movePoint.position + normalHoriz, 0.2f, obstacleMask))
                {
                    normalHoriz.Normalize();
                    movePoint.position += normalHoriz;
                }
            }

            else if (Math.Abs(verticalMove) == 1)
            {

                Vector3 normalVert = new(0f, verticalMove, 0f);
                if (!Physics2D.OverlapCircle(movePoint.position + normalVert, 0.2f, obstacleMask))
                {
                    normalVert.Normalize();
                    movePoint.position += normalVert;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // obstacle layer
        if(collision.gameObject.layer == 3)
        {
            transform.position = currentPosition;
            movePoint.position = currentPosition;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // obstacle layer
        if (collision.gameObject.layer == 3)
        {
            transform.position = currentPosition;
            movePoint.position = currentPosition;
        }
    }
}
