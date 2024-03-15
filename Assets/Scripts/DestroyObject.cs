using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 1.5f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
