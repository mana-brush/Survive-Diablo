using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {

        public SpriteRenderer spriteRenderer;
        public Sprite N, E, S, W; 
        
        [SerializeField] private LayerMask obstacleLayer;
        [SerializeField] private float speed = 5f;
        [SerializeField] private Transform playerMovePoint;

        private InputAction _moveAction;
        private InputAction _cursorAction;
        private const float Zero = 0f;
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
            transform.position =
                Vector3.MoveTowards(transform.position, playerMovePoint.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, playerMovePoint.position) <= 0.05f)
            {
                Vector2 direction = _moveAction.ReadValue<Vector2>();
                if (!Physics2D.OverlapCircle(playerMovePoint.position + new Vector3(direction.x, direction.y, Zero),
                        .2f,
                        obstacleLayer))
                {
                    playerMovePoint.position += new Vector3(direction.x, direction.y, Zero);
                }
            }

            Vector2 cursorPosition = _mainCamera.ScreenToWorldPoint(_cursorAction.ReadValue<Vector2>());
            float angle = Mathf.Atan2(cursorPosition.y - transform.position.y, cursorPosition.x - transform.position.x);
            float angleDeg = (180 / Mathf.PI) * angle - 90;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleDeg));
            
            if (angle < 0) angle += 360; 

            // Divide the full circle (360) into 8 steps (45 degrees each)
            float step = 45f;
        
            // Determine which direction slice the angle falls into
            if (angle < step / 2f || angle >= 360f - step / 2f) spriteRenderer.sprite = E; // Right
            else if (angle < step * 2.5f) spriteRenderer.sprite = N; // Up
            else if (angle < step * 4.5f)
            {
                spriteRenderer.sprite = W; // Left
                spriteRenderer.flipX = true;
            }
            else if (angle < step * 6.5f) spriteRenderer.sprite = S; // Down
            
        }

        public InputAction GetMoveAction() => _moveAction;

    }

}