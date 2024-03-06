using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimationController : MonoBehaviour
{
    FrogMovementScript frogMovementScript;
    [SerializeField] private Sprite upStill;
    [SerializeField] private Sprite downStill;
    [SerializeField] private Sprite leftStill;
    [SerializeField] private Sprite rightStill;
    [SerializeField] private Sprite upJump;
    [SerializeField] private Sprite downJump;
    [SerializeField] private Sprite leftJump;
    [SerializeField] private Sprite rightJump;

    // Start is called before the first frame update
    void Start()
    {
        frogMovementScript = GetComponent<FrogMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(frogMovementScript.isMoving)
        {
            switch (frogMovementScript.currentDirection)
            {
                case FrogMovementScript.Direction.Up:
                    GetComponent<SpriteRenderer>().sprite = upJump;
                    break;
                case FrogMovementScript.Direction.Down:
                    GetComponent<SpriteRenderer>().sprite = downJump;
                    break;
                case FrogMovementScript.Direction.Left:
                    GetComponent<SpriteRenderer>().sprite = leftJump;
                    break;
                case FrogMovementScript.Direction.Right:
                    GetComponent<SpriteRenderer>().sprite = rightJump;
                    break;
            }
        }
        else
        {
            switch (frogMovementScript.currentDirection)
            {
                case FrogMovementScript.Direction.Up:
                    GetComponent<SpriteRenderer>().sprite = upStill;
                    break;
                case FrogMovementScript.Direction.Down:
                    GetComponent<SpriteRenderer>().sprite = downStill;
                    break;
                case FrogMovementScript.Direction.Left:
                    GetComponent<SpriteRenderer>().sprite = leftStill;
                    break;
                case FrogMovementScript.Direction.Right:
                    GetComponent<SpriteRenderer>().sprite = rightStill;
                    break;
            }
        }
    }
}
