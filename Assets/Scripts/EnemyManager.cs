using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "HeroAttackPoint")
        {
            TakeDamage(50);
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