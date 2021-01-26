using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CannonFire : MonoBehaviour
{
    [SerializeField] private List<Bullet> _templates;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _direction;
    [SerializeField] private float _force;
    [SerializeField] private float _intervalBetweenShots;
    [SerializeField] private BulletController _bulletController;
    private float _counter;
    private bool _isCannonHasBullet;
    private Bullet _bullet;

    private void Update()
    {
        _counter += Time.deltaTime;
        
        if (!_isCannonHasBullet && _counter >= _intervalBetweenShots)
        {
            _counter = 0;
            LoadBullet();
        }
    }

    public void FireClick()
    {
        if (_isCannonHasBullet)
        {
            _counter = 0;
            Fire();
        }
    }

    private void LoadBullet()
    {
        _bullet = Instantiate(_templates[Random.Range(0, _templates.Count)], _spawnPoint.position, Quaternion.identity);
        _bullet.transform.SetParent(gameObject.transform);
        _isCannonHasBullet = true;
    }

    private void Fire()
    {
        var rigidBody = _bullet.GetComponent<Rigidbody>();
        rigidBody.AddForce(_direction.position * _force, ForceMode.Impulse);
        rigidBody.useGravity = true;
        rigidBody.transform.SetParent(null);
        _bulletController.AddBulletToList(_bullet);
        
        _isCannonHasBullet = false;
    }
}
