using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth;

    public event Action<float> HealthChanged;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            Debug.Log(gameObject.name + " Получил урон: " + damage);

            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, _maxHealth);

            HealthChanged?.Invoke(_currentHealth);

            if (_currentHealth <= 0f)
            {
                Die();
            }
        }
    }

    public void RestoreHealth(float heal)
    {
        if (heal > 0)
        {
            Debug.Log(gameObject.name + " Восстановил здоровье:  " + heal);

            _currentHealth = Mathf.Clamp(_currentHealth + heal, 0f, _maxHealth);

            HealthChanged?.Invoke(_currentHealth);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}