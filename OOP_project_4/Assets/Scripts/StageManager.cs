using UnityEngine;

public class StageManager : MonoBehaviour
{
    private float spawnTimer = 0f;
    private float spawnInterval = 0.5f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            EnemyManager.Instance.SpawnEnemy(Random.Range(0,4));
            spawnInterval = Random.Range(1, 2.0f);
            spawnTimer = 0f;
        }
    }
}
