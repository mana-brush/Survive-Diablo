using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _am;
        private PlayerMovement _pm;
        private SpriteRenderer _sr;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _am = GetComponent<Animator>();
            _pm = GetComponent<PlayerMovement>();
            _sr = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            InputAction moveAction = _pm.GetMoveAction();
            if (moveAction.inProgress)
            {
                _am.SetBool("Move", true);
                SpriteDirectionChecker(moveAction);
            }
            else
            {
                _am.SetBool("Move", false);
            }
        }

        void SpriteDirectionChecker(InputAction moveAction)
        {
            Vector2 direction = moveAction.ReadValue<Vector2>();
            if (direction.x > 0)
            {
                _sr.flipX = false;
            }
            else
            {
                _sr.flipX = true;
            }

        }
    }
}