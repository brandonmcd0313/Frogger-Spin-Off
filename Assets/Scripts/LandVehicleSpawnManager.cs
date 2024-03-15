using System.Collections;
using UnityEngine;

public class LandVehicleSpawnManager : MonoBehaviour
{
    public GameObject[] landVehiclePrefabs;
    [Tooltip("The spawn rate of the land vehicles in seconds")]
    public float[] landVehicleSpawnRates; // Changed to float array for wait times

    // Start is called before the first frame update
    void Start()
    {
        // Check if there's a mismatch in the lengths of the arrays
        if (landVehiclePrefabs.Length != landVehicleSpawnRates.Length)
        {
            Debug.Log("Prefab and spawn rates array lengths do not match!");
            return;
        }

        // Start coroutines for each prefab
        for (int i = 0; i < landVehiclePrefabs.Length; i++)
        {
            StartCoroutine(SpawnPrefab(i));
        }
    }

    IEnumerator SpawnPrefab(int prefabIndex)
    {
        // Ensure the index is within the bounds of the prefab array
        if (prefabIndex < 0 || prefabIndex >= landVehiclePrefabs.Length)
        {
            Debug.Log("Prefab index out of range.");
            yield break;
        }

        while (true) // Infinite loop to keep spawning prefabs
        {
            // Instantiate the prefab
            Instantiate(landVehiclePrefabs[prefabIndex], transform.position, Quaternion.identity);


            // Wait for the specified time with a second of viariation
            yield return new WaitForSeconds(landVehicleSpawnRates[prefabIndex] + Random.Range(-0.2f, 1f));
        }
    }
}
