using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeIcons;
    public GameObject frogPrefab;
    public int lifeCount = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveLife()
    {
        if (lifeCount > 0)
        {
            lifeCount--; // Decrease the life count by one

            // Destroy the last active life icon and remove it from the array
            if (lifeIcons[lifeCount] != null)
            {
                Destroy(lifeIcons[lifeCount]);
                lifeIcons[lifeCount] = null; // This line is optional, it clears the reference in the array
            }
            Invoke("SpawnNewFrog", 1f);
        }
    }

    public void SpawnNewFrog()
    {
        if(lifeCount > 0)
        {
            // Instantiate a new frog at the starting position
            Instantiate(frogPrefab, new Vector3(0, -4, 0), Quaternion.identity);
        }
    }
}
