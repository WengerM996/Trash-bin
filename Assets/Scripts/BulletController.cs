using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool destroyBulletInTrash;
    
    [SerializeField] private DestroyPoint _destroyPoint;
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
        _destroyPoint.active = status;
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
