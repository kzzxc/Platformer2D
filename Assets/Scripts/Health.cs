using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log( gameObject.name + " Получил урон: " + damage);
        _currentHealth -= damage;

        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);

        if (_currentHealth <= 0f)
        {
            Die();
        }
    }

    public void RestoreHealth(float heal)
    {
        if (heal > 0)
        {
            Debug.Log(gameObject.name + " Восстановил здоровье:  " + heal);
            _currentHealth += heal;
            _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
