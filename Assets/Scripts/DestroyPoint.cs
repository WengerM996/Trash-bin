using System;
using UnityEngine;

public class DestroyPoint : MonoBehaviour
{
    private bool active;

    public void SetStatus(bool status)
    {
        active = status;
    }
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
            if (other.gameObject.TryGetComponent(out Bullet bullet))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
