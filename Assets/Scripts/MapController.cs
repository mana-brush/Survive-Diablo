using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public GameObject currentChunk;
    
    [SerializeField]
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public LayerMask terrainMask;
    private Vector3 _noTerrainPosition;
    private PlayerMovement _pm;
    
    public List<GameObject> spawnedChunks;
    private GameObject _latestChunk;
    public float maxOpDist;
    private float _opDist;

    private float _optimizerCooldown; 
    public float optimizerCooldownDuration;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pm = FindFirstObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {

        if (!currentChunk)
        {
            return;
        }
        
        Vector2 moveDirection = _pm.GetMoveDirection();
        if (moveDirection is { x: > 0, y: 0 }) // right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightPlaceholder").position, checkerRadius, terrainMask))
            {
                _noTerrainPosition = currentChunk.transform.Find("RightPlaceholder").position;
                SpawnChunk();
            }
        }
        else if (moveDirection is { x: < 0, y: 0 }) // left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftPlaceholder").position, checkerRadius, terrainMask))
            {
                _noTerrainPosition = currentChunk.transform.Find("LeftPlaceholder").position;
                SpawnChunk();
            }
        }        
        else if (moveDirection is { x: 0, y: > 0 }) // up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("TopPlaceholder").position, checkerRadius, terrainMask))
            {
                _noTerrainPosition = currentChunk.transform.Find("TopPlaceholder").position;
                SpawnChunk();
            }
        }
        else if (moveDirection is { x: 0, y: < 0 }) // down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("BottomPlaceholder").position, checkerRadius, terrainMask))
            {
                _noTerrainPosition = currentChunk.transform.Find("BottomPlaceholder").position;
                SpawnChunk();
            }
        }
        else if (moveDirection is { x: > 0, y: > 0 }) // top right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("TopRightPlaceholder").position, checkerRadius, terrainMask))
            {
                _noTerrainPosition = currentChunk.transform.Find("TopRightPlaceholder").position;
                SpawnChunk();
            }
        }
        else if (moveDirection is { x: > 0, y: < 0 }) // bottom right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("BottomRightPlaceholder").position, checkerRadius, terrainMask))
            {
                _noTerrainPosition = currentChunk.transform.Find("BottomRightPlaceholder").position;
                SpawnChunk();
            }
        }
        else if (moveDirection is { x: < 0, y: > 0 }) // top left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("TopLeftPlaceholder").position, checkerRadius, terrainMask))
            {
                _noTerrainPosition = currentChunk.transform.Find("TopLeftPlaceholder").position;
                SpawnChunk();
            }
        }
        else if (moveDirection is { x: < 0, y: < 0 }) // bottom left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("BottomLeftPlaceholder").position, checkerRadius, terrainMask))
            {
                _noTerrainPosition = currentChunk.transform.Find("BottomLeftPlaceholder").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        GameObject chunk = Instantiate(terrainChunks[rand], _noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(chunk);
    }

    void ChunkOptimizer()
    {
        
        _optimizerCooldown -= Time.deltaTime;

        if (_optimizerCooldown <= 0f)
        {
            _optimizerCooldown = optimizerCooldownDuration;
        }
        else
        {
            return;
        }
        
        foreach (GameObject chunk in spawnedChunks)
        {
            _opDist = Vector3.Distance(chunk.transform.position, player.transform.position);
            if (_opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
