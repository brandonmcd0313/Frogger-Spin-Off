using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    [SerializeField] bool isStartingFromLeft;
    [SerializeField] float speed;
    [SerializeField] float YPosition;
    [SerializeField] float DipWaitTime;
    [SerializeField] float DipTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dipping());
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

    IEnumerator Dipping()
    {
        while (true)
        {
            yield return new WaitForSeconds(DipWaitTime);
            StartCoroutine(DipUnderWater());
            yield return new WaitForSeconds(DipTime);
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

    IEnumerator DipUnderWater()
    {
       
        //start animation clip
        GetComponent<Animator>().SetBool("Idle", false);
        GetComponent<Animator>().SetBool("DipUnder", true);
        //print("Dipping");
        yield return new WaitForSeconds(DipTime*0.35f);
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(DipTime*0.15f);
        //play come back up animation
        GetComponent<Animator>().SetBool("DipUnder", false);
        GetComponent<Animator>().SetBool("Arise", true);
        //disable the box collider
       // print("Arising");
        yield return new WaitForSeconds(DipTime/2);
        GetComponent<Animator>().SetBool("Arise", false);
        GetComponent<Animator>().SetBool("Idle", true);
      //  print("Idle");
        //enable the box collider
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
