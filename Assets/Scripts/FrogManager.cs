using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogManager : MonoBehaviour
{
    public GameObject waterDeath;
    public GameObject landDeath;
    public AudioClip deathSound;
    public AudioClip winSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            LandDie();
        }
        else if (collision.gameObject.tag == "Floating")
        {
            // Make the frog a child of the floating object
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floating")
        {
            // Remove the parent, making the frog a top-level object in the hierarchy again
            transform.SetParent(null);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            //check if in contact with a floating object

            // Check for nearby floating objects using an overlap box
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.5f, 0.5f), 0);

            bool foundFloatingObject = false;
            foreach (var hit in hits)
            {
                if(hit.gameObject.tag == "Win")
                {
                   if(hit.gameObject.GetComponent<EndSpot>().spotFilled == false)
                    {
                        hit.gameObject.GetComponent<EndSpot>().spotFilled = true;
                        Win();
                        return;
                    }
                   else
                    {
                        LandDie();
                        return;
                    }
                }

                if (hit.gameObject.tag == "Floating")
                {
                    //if the object is in the direction of the frog movement it can become the parent
                    //this is a horrible solution but it just works

                    //they are close?
                    if (Mathf.Abs(hit.transform.position.y - transform.position.y) < 0.1f)
                    {
                        
                        // Make the frog a child of the floating object
                        transform.SetParent(hit.transform);

                    }
                    else if(GetComponent<FrogMovementScript>().currentDirection == FrogMovementScript.Direction.Up)
                    {
                        if(hit.transform.position.y > transform.position.y)
                        {
                            // Make the frog a child of the floating object
                            transform.SetParent(hit.transform);
                        }
                    }
                    else if  (GetComponent<FrogMovementScript>().currentDirection == FrogMovementScript.Direction.Down)
                    {
                            if (hit.transform.position.y < transform.position.y)
                            {
                                // Make the frog a child of the floating object
                                transform.SetParent(hit.transform);
                            }
                    }
                    
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

    private void Update()
    {
        if (transform.position.x > 8f)
        {
            //if the object is off the screen, destroy it
            LandDie();
        }

        if (transform.position.x < -8f)
        {
            //if the object is off the screen, destroy it
            LandDie();
        }
    }
    void WaterDie()
    {
        print("Frog died in water");
        Instantiate(waterDeath, transform.position, Quaternion.identity);
        GameObject.Find("LifeManager").GetComponent<LifeManager>().RemoveLife();
        GameObject.Find("AudioController").GetComponent<AudioSource>().PlayOneShot(deathSound);
        Destroy(gameObject);
    }

    void LandDie()
    {
        print("Frog died on land");
        Instantiate(landDeath, transform.position, Quaternion.identity);
        GameObject.Find("LifeManager").GetComponent<LifeManager>().RemoveLife();
        GameObject.Find("AudioController").GetComponent<AudioSource>().PlayOneShot(deathSound);
        Destroy(gameObject);
    }

    void Win()
    {
        GameObject.Find("AudioController").GetComponent<AudioSource>().PlayOneShot(winSound);
        print("Frog won");
        //check all EndSpots to see if the game is over
        GameObject[] endSpots = GameObject.FindGameObjectsWithTag("Win");
        bool gameWon = true;
        foreach (var spot in endSpots)
        {
            if(spot.GetComponent<EndSpot>().spotFilled == false)
            {
                gameWon = false;
                break;
            }
        }
        if (gameWon)
        {
            GameObject.Find("WinScreen").GetComponent<WinScreen>().EnableWinScreen();
        }
        else
        {
            GameObject.Find("LifeManager").GetComponent<LifeManager>().SpawnNewFrog();
        }
        Destroy(gameObject);
    }
}
