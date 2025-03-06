using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action Crashed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IInteractable interactable))
            Crashed?.Invoke();
    }
}
