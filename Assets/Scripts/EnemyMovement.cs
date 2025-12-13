using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    private bool _isAggrod;
        
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

    public bool IsAggrod()
    {
        return _isAggrod;
    }
}
