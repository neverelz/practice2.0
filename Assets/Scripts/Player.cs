using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _healPerSecond;
    [SerializeField] private float _health;

    public void TakeDamage(int damage)
    {
        if (_health - damage <= 0)
        {
            Debug.Log("Умер");
            return;
        }
        _health -= damage;
    }

    private void Heal()
    {
        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
            return;
        }
        _health += Time.deltaTime * _healPerSecond;
    }
    void Update()
    {
        Heal();
    }
}
