using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ZombieStatsRegulator : MonoBehaviour
{
    [SerializeField] private float Health = 100;
    public static float MaxTenacity = 100;
    private float Tenacity = MaxTenacity;
    [Header("≤ª”√±‡º≠")]
    public Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void CheckRemainingHealth()
    {
        if (Health <= 0)
        {
            _animator.SetTrigger("Melee");
        }
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        CheckRemainingHealth();
    }

    public void ReduceTenacity(float tenacityReduction)
    {
        Tenacity -= tenacityReduction;
        if (Tenacity <= 0)
        {
            Tenacity = 0;
            Variables.Object(gameObject).Set("IsStunned", true);
        }
    }
    public void ResetTenacity()
    {
        Tenacity = MaxTenacity;
        Variables.Object(gameObject).Set("IsStunned", false);
    }
}
