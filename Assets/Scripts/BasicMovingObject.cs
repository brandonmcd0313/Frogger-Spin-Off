using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovingObject : MonoBehaviour
{
   [SerializeField] bool isStartingFromLeft;
    [SerializeField] float speed;
    [SerializeField] float YPosition;
    // Start is called before the first frame update
    void Start()
    {
        //spawn the object at the left or right edge of the screen
        if (isStartingFromLeft)
        {
            transform.position = new Vector3(-8f, YPosition, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(8f, YPosition, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move the object to the opposite side of the screen
        if (isStartingFromLeft)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x > 8f)
            {
                //if the object is off the screen, destroy it
               Destroy(gameObject);
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x < -8f)
            {
                //if the object is off the screen, destroy it
                Destroy(gameObject);
            }
        }
    }
}
