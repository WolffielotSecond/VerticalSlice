using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionRadius, _colliders, _interactableMask);
        /*
        for (int i = 0; i < _numFound; i++)
        {
            if (_colliders[i].TryGetComponent(out IInteractable interactable))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        */
    }
}
