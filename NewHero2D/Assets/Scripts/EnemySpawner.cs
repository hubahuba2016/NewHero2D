using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1.5f;
    public float spawnDistance = 10f;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        // Random angle around player
        float angle = Random.Range(0f, 360f);
        Vector2 spawnDir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        // Spawn outside player radius
        Vector2 spawnPos = (Vector2)player.position + spawnDir * spawnDistance;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}

