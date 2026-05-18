using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStatsRegulator : MonoBehaviour, IDamagable
{
    [SerializeField] private float Health = 100;
    public static float MaxTenacity = 100;
    private float Tenacity = MaxTenacity;
    [Header("不用编辑")]
    public Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void CheckRemainingHealth()
    {
        //die
        if (Health <= 0)
        {
            // 正确用法：调用静态方法 Variables.Object(gameObject) 来获取目标对象的 Variables 实例，
            // 然后调用 Set 方法设置键值对。
            // 这里把敌人引用清空，使用 Singleton 中的 _player 对象作为目标。
            Variables.Object(Singleton.Instance._player).Set("enemy ref", null);

            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            _animator.SetTrigger("Melee");
        }
        else
        {
            _animator.SetTrigger("Kicked not to death");
        }
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        Variables.Object(gameObject).Set("Alertness", 30);
        CheckRemainingHealth();
    }

    public void DealDamage(float damage)
    {
        TakeDamage(damage);
        ReduceTenacity(40);
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
