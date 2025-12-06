using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapController : MonoBehaviour
{

    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public LayerMask terrainMask;
    private Vector3 _noTerrainPosition;
    private PlayerMovement _pm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pm = FindFirstObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        Vector2 moveDirection = _pm.GetMoveDirection();
        if (moveDirection is { x: > 0, y: 0 })
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 0, 0), checkerRadius, terrainMask))
            {
                _noTerrainPosition = player.transform.position + new Vector3(20, 0, 0);
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], _noTerrainPosition, Quaternion.identity);
    }
}
