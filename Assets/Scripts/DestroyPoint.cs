using System;
using UnityEngine;

public class DestroyPoint : MonoBehaviour
{
    [NonSerialized] public bool active;

    private void OnTriggerEnter(Collider other)
    {
        CheckCollider(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CheckCollider(other);
    }

    private void CheckCollider(Collider other)
    {
        if (active)
        {
            if (other.gameObject.TryGetComponent(out Bullet Bullet))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
