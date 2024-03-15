using System.Collections;
using UnityEngine;

public class SubmarineSpawnManager : MonoBehaviour
{
    public GameObject sub1Prefab, sub1DippingPrefab, sub2Prefab, sub2DippingPrefab;
    [Tooltip("The spawn rate of Sub1 in seconds")]
    public float sub1SpawnRate;
    [Tooltip("The spawn rate of Sub2 in seconds")]
    public float sub2SpawnRate;

    // Start is called before the first frame update
    void Start()
    {
        // Start coroutines for each submarine type
        StartCoroutine(SpawnSubmarine(sub1Prefab, sub1DippingPrefab, sub1SpawnRate));
        StartCoroutine(SpawnSubmarine(sub2Prefab, sub2DippingPrefab, sub2SpawnRate));
    }

    IEnumerator SpawnSubmarine(GameObject subPrefab, GameObject subDippingPrefab, float spawnRate)
    {
        while (true) // Infinite loop to keep spawning submarines
        {
            // Decide whether to spawn the normal sub or the dipping version (20% chance for dipping)
            GameObject prefabToSpawn = Random.Range(0f, 1f) <= 0.2f ? subDippingPrefab : subPrefab;

            // Instantiate the chosen prefab
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            // Wait for the specified time with a second of variation
            yield return new WaitForSeconds(spawnRate + Random.Range(-0.2f, 1f));
        }
    }
}
