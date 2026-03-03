using System;
using System.Globalization;
using Mirror;
using UnityEngine;
using VContainer;

public class ControlPlayer : NetworkBehaviour, IMove
{
    private IMoveInput _playerInput;
    private Vector3 _directon;
    private float _powerMove = 500;
    private float _powerTorque = 300;

    private Rigidbody _rigidbody;
    [SerializeField] private GameObject _bullet;

    private void Start()
    {
        _playerInput = ServiceLocator.Instance.MoveInput;
        _playerInput.Move += OnMove;
        _playerInput.Shoot += OnShoot;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isOwned)
        {
            if (_directon.y != 0)
                _rigidbody.AddForce(transform.forward * _powerMove * _directon.y);
            if (_directon.x != 0)
                _rigidbody.AddTorque(transform.up * _powerTorque * _directon.x);
        }
    }

    private void OnMove(Vector2 vector)
    {
        _directon = vector;
    }

    public void Move(Vector3 direction)
    {
        throw new NotImplementedException();
    }

    public void OnShoot()
    {
        Debug.Log($"Shoot");
        NetworkManager.Instantiate(_bullet, transform.position, transform.rotation);
    }

    public void Shoot(Vector3 direction)
    {
        throw new NotImplementedException();
    }
}
