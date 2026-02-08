using System;
using System.Globalization;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using VContainer;

public class ControlPlayer : NetworkBehaviour, IMove
{
    private IMoveInput _playerInput;
    private Vector3 _directon;
    private float _speed = 1;

    [Inject]
    public void Construct(IMoveInput playerInput)
    {
        Debug.Log("ControlPlayer Construct");
        _playerInput = playerInput;
        _playerInput.Move += OnMove;
    }

    private void Update()
    {
        if (IsLocalPlayer)
        {
            Debug.Log("111");
        }

        //Debug.Log($"isLocalPlayer {isLocalPlayer}");
        Move(_directon * _speed * Time.deltaTime);
    }

    private void OnMove(Vector2 vector)
    {
        _directon = vector;
    }

    public override void OnNetworkSpawn()
    {
        Debug.Log("OnNetworkSpawn");
        base.OnNetworkSpawn();
    }

    public void Move(Vector3 delta)
    {
        NetworkTransform test = GetComponent<NetworkTransform>();
        transform.Translate(delta);
    }
}
