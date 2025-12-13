using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public EnemyMovement enemyMovepoint;
    public float speed;
    private Transform _player;
    
    void Start()
    {
        enemyMovepoint.transform.parent = null;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyMovepoint.transform.position, speed * Time.deltaTime);
        
        if (enemyMovepoint.IsAggrod())
        { 
            enemyMovepoint.transform.position = Vector3.MoveTowards(enemyMovepoint.transform.position, _player.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            TakeDamage(33);
            if (currentHealth <= 0)
            {
                Destroy(gameObject); // Destroy self
            }
        }
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}