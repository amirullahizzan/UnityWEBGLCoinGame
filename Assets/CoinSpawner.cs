using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin Settings")]
    public GameObject coinPrefab;               // Prefab to spawn

    [Header("Spawn Timing")]
    public float minSpawnTime = 1f;   // Minimum time between spawns
    public float maxSpawnTime = 3f;   // Maximum time between spawns

    private float timer;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnCoin();
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        timer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void SpawnCoin()
    {
        Vector3 spawnPosition = transform.position;

        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
