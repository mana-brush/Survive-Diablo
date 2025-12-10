using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    public GameObject heroAttackPoint;
    private InputAction _attackKey;
    private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _attackKey = InputSystem.actions["Attack"];
        //_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var isAttacking = _attackKey.IsPressed();
        heroAttackPoint.SetActive(isAttacking);
        if (isAttacking)
        {
            //_animator.Play("HeroAttack");
        }
    }
    
}
