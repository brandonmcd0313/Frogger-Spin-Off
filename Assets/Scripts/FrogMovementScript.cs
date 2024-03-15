using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovementScript : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float moveSpeed = 5f;
    [Tooltip("The size of one tile")]
    [SerializeField] private float scaleFactor; // Scale factor for movement
    [SerializeField] private float leftScreenEdge;
    [SerializeField] private float rightScreenEdge;
    [SerializeField] private float downScreenEdge;
    private Vector3 movePoint;
    private Vector3 offset; // Offset from the parent object
    public Direction currentDirection;
    public bool isMoving = false;
    private bool isParented = false;
    GameObject parent;
    public AudioClip jump;
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    void Start()
    {
        startPosition = new Vector3(-scaleFactor, downScreenEdge, 0f);
        transform.position = startPosition;
        movePoint = startPosition;
        offset = Vector3.zero; // Initial offset is zero
    }

    void Update()
    {
        if (transform.parent == null && isParented)
        {
            isParented = false;
            offset = Vector3.zero;
        }
        else if (transform.parent != null && !isParented)
        {
            parent = transform.parent.gameObject;
            isParented = true;
            CalculateParentOffset();
        }
        
        //the parent object has changed
        if(transform.parent != null )
        {
            if(transform.parent.gameObject != parent)
            {
                parent = transform.parent.gameObject;
                CalculateParentOffset();
            }
        }
        if(!canMove)
        {
            return;
        }

        Move();
    }

    void Move()
    {
        if (transform.parent != null)
        {
            movePoint = transform.parent.position + offset;
        }

        //move towards a set position, position needs to change if on a floating object
        transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);
        isMoving = Vector3.Distance(transform.position, movePoint) >= 0.05f;
        UpdateDirection();

        if (!isMoving)
        {
            transform.position = movePoint;
            PlayerControlledMovement();
        }
    }

    void UpdateDirection()
    {
        if (movePoint.y > transform.position.y) currentDirection = Direction.Up;
        else if (movePoint.y < transform.position.y) currentDirection = Direction.Down;
        else if (movePoint.x < transform.position.x) currentDirection = Direction.Left;
        else if (movePoint.x > transform.position.x) currentDirection = Direction.Right;
    }

    void PlayerControlledMovement()
    {
        //adjust the move point based on input
        if (Vector3.Distance(transform.position, movePoint) <= 0.05f)
        {
            Vector3 moveDirection = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                this.GetComponent<AudioSource>().PlayOneShot(jump);
                moveDirection = new Vector3(0f, scaleFactor, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                this.GetComponent<AudioSource>().PlayOneShot(jump);
                moveDirection = new Vector3(0f, -scaleFactor, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                this.GetComponent<AudioSource>().PlayOneShot(jump);
                moveDirection = new Vector3(-scaleFactor, 0f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {this.GetComponent<AudioSource>().PlayOneShot(jump);
                moveDirection = new Vector3(scaleFactor, 0f, 0f);
            }

            offset += moveDirection;
            if (transform.parent == null)
            {
                movePoint += moveDirection;
            }
            ScreenBoundsCheck();
        }
    }

    void ScreenBoundsCheck()
    {
        //lock movement to the screen bounds
        Vector3 newPosition = transform.parent != null ? transform.parent.position + offset : movePoint;
        if (newPosition.x < leftScreenEdge || newPosition.x > rightScreenEdge || newPosition.y < downScreenEdge)
        {
            offset -= movePoint - transform.position;
            movePoint = transform.position;
        }
    }

    // Call this method when setting the frog's parent to a floating object
    public void CalculateParentOffset()
    {
        offset = transform.position - transform.parent.position;
        offset.y = 0;
        
    }
}

