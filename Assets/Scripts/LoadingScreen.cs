using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoadingScreen : MonoBehaviour
{
    //TEXT MESH PRO IS BROKEN AAAAAAAAAAAA

    //[SerializeField] private TextMeshProUGUI loadingText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Frog").GetComponent<FrogMovementScript>().canMove = false;
         Invoke("DestroyScreen", 5f);
    }

    void DestroyScreen()
    {
        GameObject.Find("Frog").GetComponent<FrogMovementScript>().canMove = true;
        Destroy(gameObject);
    }
 
}
