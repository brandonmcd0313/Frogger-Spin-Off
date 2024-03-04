using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovementScript : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float moveSpeed = 5f;
    [Tooltip("The size of one tile")]
    [SerializeField] private float scaleFactor; // Scale factor for movement
    [SerializeField] private float leftScreenEdge;
    [SerializeField] private float rightScreenEdge;
    [SerializeField] private float downScreenEdge;
    private Vector3 movePoint;
    public Direction currentDirection;
    public bool isMoving = false;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(-scaleFactor, downScreenEdge, 0f);
        transform.position = startPosition;
        movePoint = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {
        // Move the frog towards the movePoint position
        transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);

        // If the frog is moving, set isMoving to true
        if (Vector3.Distance(transform.position, movePoint) >= 0.05f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //set current direction based on the movePoint
        if (movePoint.y > transform.position.y)
        {
            currentDirection = Direction.Up;
        }
        else if (movePoint.y < transform.position.y)
        {
            currentDirection = Direction.Down;
        }
        else if (movePoint.x < transform.position.x)
        {
            currentDirection = Direction.Left;
        }
        else if (movePoint.x > transform.position.x)
        {
            currentDirection = Direction.Right;
        }
        else
        {
            //default direction
            currentDirection = Direction.Up;
        }

        // Guard clauses to prevent movement off the screen
        if (transform.position.x < leftScreenEdge)
        {
            movePoint = new Vector3(leftScreenEdge, movePoint.y, movePoint.z);
        }
        else if (transform.position.x > rightScreenEdge)
        {
            movePoint = new Vector3(rightScreenEdge, movePoint.y, movePoint.z);
        }
        else if (transform.position.y < downScreenEdge)
        {
            movePoint = new Vector3(movePoint.x, downScreenEdge, movePoint.z);
        }

        //if the frog is near the movePoint position, lock to the grid
        if (Vector3.Distance(transform.position, movePoint) <= 0.05f)
        {
            transform.position = movePoint;
        }

        // Only allow movement if the frog is at the movePoint position
        if (Vector3.Distance(transform.position, movePoint) <= 0.05f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                movePoint += new Vector3(0f, scaleFactor, 0f); // Move up
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                movePoint += new Vector3(0f, -scaleFactor, 0f); // Move down
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                movePoint += new Vector3(-scaleFactor, 0f, 0f); // Move left
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                movePoint += new Vector3(scaleFactor, 0f, 0f); // Move right
            }
        }
    }

  
}
