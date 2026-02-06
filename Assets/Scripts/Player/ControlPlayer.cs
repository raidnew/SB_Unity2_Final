using System;
using Unity.Netcode;
using UnityEngine;
using VContainer;

public class ControlPlayer : NetworkBehaviour, IMove
{
    private IMoveInput _playerInput;

    [Inject]
    public void Construct(IMoveInput playerInput)
    {
        _playerInput = playerInput;
        _playerInput.Move += OnMove;
        Debug.Log("_playerInput: " + _playerInput);
    }

    private void Awake()
    {
        //Debug.Log($"isLocalPlayer {isLocalPlayer}");

    }

    private void OnMove(Vector2 vector)
    {
        Debug.Log(vector);
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            Debug.Log("Control player Awake Local");
        }
        else
        {
            Debug.Log("Control player Awake Network");
        }
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
