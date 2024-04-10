using System.Collections;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private const string EnemiesLayer = "Enemies";

    [SerializeField] private float _abilityCooldown = 5f; 
    [SerializeField] private float _abilityDuration = 6f;
    [SerializeField] private float _healthTransferRate = 10f;
    [SerializeField] private float _abilityRadius = 2f;

    private bool _abilityAvailable = true;
    private Health _playerHealth;
    private Coroutine _cooldownCoroutine;

    public bool AbilityAvailable => _abilityAvailable;

    private void Start()
    {
        _playerHealth = GetComponent<Health>();
    }

    public void ActivateAbility()
    {
        if (_abilityAvailable)
        {
            StartCoroutine(ActivateVampirism());
            _abilityAvailable = false;
        }
    }

    private IEnumerator ActivateVampirism()
    {
        float timer = 0f;

        while (timer < _abilityDuration)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, _abilityRadius, LayerMask.GetMask(EnemiesLayer));

            foreach (var enemyCollider in hitEnemies)
            {
                Health enemyHealth = enemyCollider.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    float healthToTransfer = _healthTransferRate * Time.deltaTime;
                    float remainingHealth = enemyHealth.CurrentHealth - healthToTransfer;

                    if (remainingHealth < 0)
                    {
                        healthToTransfer += remainingHealth;
                    }

                    enemyHealth.TakeDamage(healthToTransfer);
                    _playerHealth.RestoreHealth(healthToTransfer);
                }
            }

            timer += Time.deltaTime;
            yield return null;
        }

        StartCooldown();
    }

    private void StartCooldown()
    {
        if (_cooldownCoroutine == null)
        {
            _cooldownCoroutine = StartCoroutine(CooldownCoroutine());
        }
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(_abilityCooldown);
        _abilityAvailable = true;
        _cooldownCoroutine = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
