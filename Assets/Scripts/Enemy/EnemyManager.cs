using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;


namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {

        public SpriteRenderer spriteRenderer;
        public int maxHealth = 100;
        public int currentHealth;
        public HealthBar healthBar;
        public EnemyMovement enemyMovePoint;
        public float speed;

        private bool _isDead;
        private Transform _player;

        private Color _originalColor;
        private Color _flashColor = Color.white;
        private float _flashDuration = 0.1f;

        void Start()
        {
            enemyMovePoint.transform.parent = null;
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            if (spriteRenderer != null)
            {
                _originalColor = spriteRenderer.color;
            }

        }

        void Update()
        {

            if (_isDead) return;

            transform.position = Vector3.MoveTowards(transform.position, enemyMovePoint.transform.position,
                speed * Time.deltaTime);

            if (enemyMovePoint.IsAggrod())
            {
                enemyMovePoint.transform.position = Vector3.MoveTowards(enemyMovePoint.transform.position,
                    _player.position, speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D otherObject)
        {

            if (_isDead)
            {
                return;
            }

            if (otherObject.gameObject.name == "HeroAttackPoint")
            {
                TakeDamage(50);
                if (currentHealth <= 0)
                {
                    _isDead = true;
                }
            }
        }

        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (spriteRenderer != null)
            {
                StartCoroutine(FlashEffect());
            }
        }

        private IEnumerator FlashEffect()
        {
            spriteRenderer.color = _flashColor;
            yield return new WaitForSeconds(_flashDuration);
            spriteRenderer.color = _originalColor;
        }

        public void Revive()
        {
            _isDead = false;
            currentHealth = maxHealth / 2;
        }

    }
}