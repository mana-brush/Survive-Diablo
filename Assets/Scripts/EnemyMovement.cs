using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);
    }
}
