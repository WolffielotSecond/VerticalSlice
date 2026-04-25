using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ZombieAttack : MonoBehaviour
{
    public Animator animator;
    public ZombieAttackSphereScript attackSphere;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Attack()
    {
        if (Singleton.Instance._player.GetComponent<NewPlayer>().GetParrying())
        {
            GetComponent<ZombieStatsRegulator>().ReduceTenacity(100);
            Singleton.Instance._player.GetComponent<NewPlayer>().DoCameraShake();
        }
        else
        {
            if (attackSphere.player_ref != null)
            {
                Debug.Log("Player hit!");
            }
        }
    }

    public void StartRootMotion()
    {
        animator.applyRootMotion = true;
    }

    public void StopRootMotion()
    {
        animator.applyRootMotion = false;
    }

    public void StopAttacking()
    {
        Variables.Object(gameObject).Set("is Attacking", false);
    }

    public bool IsStunned()
    {
        return Variables.Object(gameObject).Get<bool>("IsStunned");
    }
    
    public void Die()
    {
        Debug.Log("Play VFX");
        Destroy(gameObject);
    }
    
}
