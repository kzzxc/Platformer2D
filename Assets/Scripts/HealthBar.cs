using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    [SerializeField] private float _smoothSpeed = 1f;

    private Coroutine _smoothCoroutine;
    private float _targetValue;

    private void Start()
    {
        _slider.value = _health.CurrentHealth / _health.MaxHealth;
        _targetValue = _slider.value;
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float newHealth)
    {
        _targetValue = newHealth / _health.MaxHealth;

        if (_smoothCoroutine != null)
            StopCoroutine(_smoothCoroutine);

        _smoothCoroutine = StartCoroutine(SmoothHealthBar());
    }

    private IEnumerator SmoothHealthBar()
    {
        while (!Mathf.Approximately(_slider.value, _targetValue))
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _smoothSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
