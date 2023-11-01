using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 3;

    public int Health { get; private set; }
    public event UnityAction PlayerDied;
    public event UnityAction<int> PlayerHealthDamaged;

    private Animator _animator;

    private void Start()
    {
        Health = _health;
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent<Barrier>(out Barrier barrier))
        {
            if (barrier.Damge > 0)
            {
                TakeDamage(barrier.Damge);
            }
        }
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;

        PlayerHealthDamaged?.Invoke(_health);

        if (_health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerDied?.Invoke();

        _animator.SetBool("IsDead",true);
    }
}
