using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    // 싱글톤
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private List<Enemy> enemies = new List<Enemy>();
    [SerializeField] private TypingInput typingInput;
    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private int poolSize = 10;
    private List<Queue<Enemy>> enemyPools = new List<Queue<Enemy>>();
    
    public string[] wordPool = new string[]
    {
        "apple", "banana", "cat", "dog", "bear",
        "water", "fire", "earth", "wind", "light",
        "dark", "stone", "tree", "grass", "river",
        "mountain", "sky", "cloud", "storm", "rain",
        "snow", "ice", "wind", "heat", "metal",
        "magic", "spell", "power", "energy", "speed",
        "fast", "slow", "strong", "weak", "smart",
        "ghost", "zombie", "spirit", "demon", "shadow",
        "knight", "sword", "shield", "dragon", "giant",
        "robot", "laser", "night", "day", "time",
        "space", "orbit", "planet", "star", "nova",
        "alpha", "beta", "gamma", "omega", "delta",
        "virus", "system", "random", "enemy", "danger",
        "alert", "focus", "target", "point", "skill"
    };

    private void Start()
    {
        typingInput.OnEnter += HandleSubmit;

        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            Queue<Enemy> pool = new Queue<Enemy>();
            for (int j = 0; j < poolSize; j++)
            {
                Enemy obj = Instantiate(enemyPrefabs[i]);
                obj.gameObject.SetActive(false);
                obj.typeIndex = i;
                pool.Enqueue(obj);
            }
            enemyPools.Add(pool);
        }

        SpawnEnemy(0);
    }

    // Enemy spawn
    public Enemy SpawnEnemy(int typeIndex)
    {
        Queue<Enemy> pool = enemyPools[typeIndex];
        Enemy enemy;

        if (pool.Count > 0)
        {
            enemy = pool.Dequeue();
        }
        else
        {
            enemy = Instantiate(enemyPrefabs[typeIndex]);
            enemy.typeIndex = typeIndex;
        }

        if (enemy.isBullet)
        {
            char randomChar = (char)Random.Range('a', 'z' + 1);
            enemy.word = randomChar.ToString();
        }
        else {
            enemy.word = wordPool[Random.Range(0, wordPool.Length)];
        }

        enemy.transform.position = GetRandomBorderPosition();
        enemy.gameObject.SetActive(true);
        enemy.Spawn();
        enemies.Add(enemy);
        return enemy;
    }

    // 랜덤 좌표 반환
    private Vector3 GetRandomBorderPosition()
    {
        float xMin = -10f;
        float xMax = 10f;
        float yMin = -5.5f;
        float yMax = 5.5f;

        // 4면 중 하나 선택
        int side = Random.Range(0, 4);

        float x = 0f;
        float y = 0f;

        switch (side)
        {
            case 0: // Top
                x = Random.Range(xMin, xMax);
                y = yMax;
                break;

            case 1: // Bottom
                x = Random.Range(xMin, xMax);
                y = yMin;
                break;

            case 2: // Left
                x = xMin;
                y = Random.Range(yMin, yMax);
                break;

            case 3: // Right
                x = xMax;
                y = Random.Range(yMin, yMax);
                break;
        }

        return new Vector3(x, y, 0f);
    }

    // Enemy return
    public void ReturnToPool(Enemy enemy)
    {
        enemy.Dead();
        enemies.Remove(enemy);
        enemy.gameObject.SetActive(false);
        enemyPools[enemy.typeIndex].Enqueue(enemy);
    }

    // 타자 입력 시 확인
    private void HandleSubmit(string input)
    {
        foreach (Enemy e in enemies)
        {
            if (e.CheckMatch(input))
            {
                e.TakeDamage(1);
                break;  // 하나만 죽이면 되는 구조라면 break
            }
        }
    }
}
