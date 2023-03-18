using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;
    public UnityEvent OnHealthEnd;

    [SerializeField, Min(0)] private float _maxHealth;
    private float _currentHealth;

    void Awake()
    {
        OnHealthEnd ??= new UnityEvent();
        _currentHealth = _maxHealth;
    }

    public float Hit(float damage)
    {
        if (damage <= 0)
            return 0;

        float res = Mathf.Min(damage, _currentHealth);
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (_currentHealth <= 0)
            OnHealthEnd?.Invoke();

        return res;
    }
}
