using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    private Animator am;
    private PlayerMovement pm;
    private SpriteRenderer sr;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        InputAction moveAction = pm.GetMoveAction();
        if (moveAction.inProgress)
        {
            am.SetBool("Move", true);
            SpriteDirectionChecker(moveAction);
        }
        else
        {
            am.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecker(InputAction moveAction)
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        if (direction.x > 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

    }
}
