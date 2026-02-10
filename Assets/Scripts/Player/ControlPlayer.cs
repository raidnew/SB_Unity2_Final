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

    private void Start()
    {
        _playerInput = ServiceLocator.Instance.MoveInput;
        _playerInput.Move += OnMove;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isOwned)
        {
            //Move(_directon * _speed * Time.deltaTime);
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

    /*
    public void Move(Vector3 delta)
    {
        transform.Translate(delta);
    }
    */
}
