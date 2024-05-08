using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactionMask;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Collider[] interactables = Physics.OverlapSphere(interactionPoint.position, interactionRadius, interactionMask);

        foreach (Collider interactable in interactables)
        {
            if (interactable.TryGetComponent(out IInteractable interactableObject))
            {
                interactableObject.Interact();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }
}
