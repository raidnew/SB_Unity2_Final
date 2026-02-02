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
        
        if (IsOwner)
        {
            Debug.Log("Control player Awake Local");
        }
        else
        {
            Debug.Log("Control player Awake Network");
        }
    }

    private void OnMove(Vector2 vector)
    {
        Debug.Log(vector);
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
