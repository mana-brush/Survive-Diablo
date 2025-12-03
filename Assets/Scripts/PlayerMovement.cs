using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform playerMovePoint;
    
    private InputAction _moveAction;
    private const float Zero = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovePoint.parent = null; // just a child for organization, clearing to remove side effects
        _moveAction = InputSystem.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerMovePoint.position, speed * Time.deltaTime);

        if (Mathf.Approximately(Vector3.Distance(transform.position, playerMovePoint.position), Zero))
        {
            if (_moveAction.inProgress)
            {
                Vector2 direction = _moveAction.ReadValue<Vector2>();
                
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    playerMovePoint.position += new Vector3(direction.x, Zero, Zero);
                }
                else
                {
                    playerMovePoint.position += new Vector3(Zero, direction.y, Zero);
                }
            }
        }
    }
    
    public InputAction GetMoveAction() => _moveAction;
}
