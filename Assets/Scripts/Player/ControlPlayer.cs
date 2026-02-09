using System;
using System.Globalization;
using Mirror;
using UnityEngine;
using VContainer;

public class ControlPlayer : NetworkBehaviour, IMove
{
    private IMoveInput _playerInput;
    private Vector3 _directon;
    private float _speed = 1;

    private void Start()
    {

        Debug.Log($"{ObjectManager.Instance}");

        _playerInput = ObjectManager.Instance.MoveInput;
        _playerInput.Move += OnMove;
    }

    private void Update()
    {
        if (isOwned)
        {
            Move(_directon * _speed * Time.deltaTime);
        }
    }

    private void OnMove(Vector2 vector)
    {
        _directon = vector;
    }

    public void Move(Vector3 delta)
    {
        transform.Translate(delta);
    }
}
