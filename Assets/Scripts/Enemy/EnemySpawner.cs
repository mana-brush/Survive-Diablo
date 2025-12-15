using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {

        public GameObject enemyPrefab;
        public GameObject bossPrefab;
        public float spawnTimer;
        private float _timer;
        private List<GameObject> _enemies;
        private readonly int _maxEnemies = 5;
        private bool _bossSpawned;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _enemies = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_bossSpawned) return;

            _timer += Time.deltaTime;
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y - 1f);
            if (_enemies.Count < _maxEnemies && _timer >= spawnTimer)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
                _enemies.Add(enemy);
                _timer = 0f;
            }
            else if (_enemies.Count == _maxEnemies && !_bossSpawned)
            {
                Instantiate(bossPrefab, spawnPosition, Quaternion.identity, transform);
                _bossSpawned = true;
            }
        }
    }
}