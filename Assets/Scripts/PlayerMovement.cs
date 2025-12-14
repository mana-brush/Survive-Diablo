using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform playerMovePoint;
    
    private InputAction _moveAction;
    private InputAction _cursorAction;
    private const float Zero = 0f;
    private Vector2 _moveDirection; 
    private Camera _mainCamera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovePoint.parent = null; // just a child for organization, clearing to remove side effects
        _moveAction = InputSystem.actions["Move"];
        _cursorAction = InputSystem.actions["Point"];
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerMovePoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, playerMovePoint.position) <= 0.1f)
        {
            Vector2 direction = _moveAction.ReadValue<Vector2>();
            if (!Physics2D.OverlapCircle(playerMovePoint.position + new Vector3(direction.x, direction.y, Zero), .2f,
                    obstacleLayer))
            {
                playerMovePoint.position += new Vector3(direction.x, direction.y, Zero);
                _moveDirection = new Vector2(direction.normalized.x, direction.normalized.y);
            }
        }

        Vector2 cursorPosition = _mainCamera.ScreenToWorldPoint(_cursorAction.ReadValue<Vector2>());
        float angle = Mathf.Atan2(cursorPosition.y - transform.position.y, cursorPosition.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angle - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleDeg));
        
    }
    
    public InputAction GetMoveAction() => _moveAction;
    
    public Vector2 GetMoveDirection() => _moveDirection;
}
