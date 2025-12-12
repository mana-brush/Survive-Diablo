using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Transform _player;
    private bool _isAggrod = false;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_isAggrod)
        { 
            transform.position = Vector3.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isAggrod = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isAggrod = false;
        }
    }
}
