using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            LandDie();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            //check if in contact with a floating object

                // Check for nearby floating objects using an overlap box
                Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.5f,0.5f), 0);

                bool foundFloatingObject = false;
                foreach (var hit in hits)
                {
                    if (hit.gameObject.tag == "Floating")
                    {
                        foundFloatingObject = true;
                        break; // Exit loop as we found a floating object
                    }
                }

                if (!foundFloatingObject)
                {
                    // No floating object in contact
                    WaterDie();
                }

                // If in contact with a floating object, do nothing
            }
    }
    
    void WaterDie()
    {
        Destroy(gameObject);
    }

    void LandDie()
    {
        Destroy(gameObject);
    }
}
