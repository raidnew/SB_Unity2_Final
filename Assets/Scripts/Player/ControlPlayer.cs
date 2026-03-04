using System;
using System.Globalization;
using Assets.Scripts.Interfaces;
using Mirror;
using UnityEngine;
using VContainer;

public class ControlPlayer : NetworkBehaviour, IMove, IShooter
{
    public Vector3 barrel => transform.position;
    public Vector3 shootDirection => transform.forward;

    private IMoveInput _playerInput;
    private Vector3 _directon;
    private float _powerMove = 500;
    private float _powerTorque = 300;

    private Rigidbody _rigidbody;
    [SerializeField] private GameObject _bullet;

    private IShooter _shooter;

    private void Start()
    {
        _playerInput = ServiceLocator.Instance.MoveInput;
        _playerInput.Move += OnMove;
        _playerInput.Shoot += OnShoot;
        _rigidbody = GetComponent<Rigidbody>();
        _shooter = GetComponent<IShooter>();
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
        //Debug.Log($"Shoot");
        //NetworkManager.Instantiate(_bullet, transform.position, transform.rotation);
        ServiceLocator.Instance.GameNetwork.Shoot(_shooter);
    }

    public void Shoot(Vector3 direction)
    {
        throw new NotImplementedException();
    }
}
