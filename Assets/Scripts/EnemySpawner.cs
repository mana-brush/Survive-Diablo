using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnTimer;
    private float _timer;
    private List<GameObject> _enemies;
    private readonly int _maxEnemiesOnScreen = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_maxEnemiesOnScreen > _enemies.Count && _timer >= spawnTimer)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y - 1f);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
            _enemies.Add(enemy);
            _timer = 0f;
        }
    }
}
