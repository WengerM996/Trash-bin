using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    [SerializeField] private DestroyPoint _destroyPoint;
    [SerializeField] private bool destroyBulletInTrash;
    private List<Bullet> _bullets;

    private void Awake()
    {
        _bullets = new List<Bullet>();
    }

    private void Start()
    {
        SetStatusDestroyPoint(destroyBulletInTrash);
    }

    public void ToggleStatusDestroyPoint(bool status)
    {
        SetStatusDestroyPoint(status);
    }

    public void AddBulletToList(Bullet bullet)
    {
        _bullets.Add(bullet);
    }

    public void ThrowOutButtonClick()
    {
        DestroyAllBullets();
    }

    private void SetStatusDestroyPoint(bool status)
    {
        _destroyPoint.SetStatus(status);
    }

    private void DestroyAllBullets()
    {
        foreach (var bullet in _bullets)
        {
            if(bullet != null)
                Destroy(bullet.gameObject);
        }
        
        _bullets.Clear();
    }
}
