using System.Collections.Generic;
using UnityEngine;

namespace Enitities.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemyPrefabs; // enemy prefabs (type)
        [SerializeField] private Transform[] spawnPoints; // spawn points
        [SerializeField] private float spawnInterval = 5f; // spawn time
        [SerializeField] private int maxEnemyCount = 100; // max enemy count
        private int count = 0; // current enemy count

        private float spawnTimer;

        private void Update()
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval && count <= maxEnemyCount)
            {
                SpawnRandomEnemy();
                spawnTimer = 0;
            }
        }

        private void SpawnRandomEnemy()
        {
            if (spawnPoints.Length == 0 || enemyPrefabs.Count == 0) return;
            count++;
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
