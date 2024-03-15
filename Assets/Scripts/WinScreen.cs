using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    bool winScreenEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(winScreenEnabled)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
        }
    }

    public void EnableWinScreen()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        winScreenEnabled = true;
    }
    
}
