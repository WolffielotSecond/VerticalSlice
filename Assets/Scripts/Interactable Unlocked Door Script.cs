using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUnlockedDoorScript : InteractableBase
{
    //[SerializeField] private GameObject key;
    public Animator _animator;

    public override void interact()
    {
        _animator.SetTrigger("Unlock");
    }
}
