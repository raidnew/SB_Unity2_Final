using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Action<Vector2> Move { get; set; }

    private InputSystem_Actions _inputSystem;

    void Awake()
    {
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Enable();
        InitMoveInput();
    }

    private void InitMoveInput()
    {
        _inputSystem.Player.Move.started += OnMove;
        _inputSystem.Player.Move.performed += OnMove;
        _inputSystem.Player.Move.canceled += OnMove;
    }

    private void DeinitMoveInput()
    {
        _inputSystem.Player.Move.started -= OnMove;
        _inputSystem.Player.Move.performed -= OnMove;
        _inputSystem.Player.Move.canceled -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Move?.Invoke(context.ReadValue<Vector2>());
    }
}


