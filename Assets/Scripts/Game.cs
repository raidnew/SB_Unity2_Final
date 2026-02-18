using System;
using UnityEngine;
using VContainer;

public class Game : MonoBehaviour
{

    private WindowsManager _windowsManager;
    private MainWindow _mainWindow;
    private MultiPlayerWindow _multiplayerWindow;

    [Inject]
    public void Construct(WindowsManager windowsManager)
    {
        _windowsManager = windowsManager;
    }

    private void Start()
    {
        OpenMainWindow();
    }

    private void OpenMainWindow()
    {
        _mainWindow = _windowsManager.OpenWindow<MainWindow>();
        _mainWindow.StartSingle += OnStartSingle;
        _mainWindow.StartMulti += OnChooseMultiplayer;
        _mainWindow.Credits += OnCredits;
    }

    private void CloseMainWindow()
    {
        _mainWindow.StartSingle -= OnStartSingle;
        _mainWindow.StartMulti -= OnChooseMultiplayer;
        _mainWindow.Credits -= OnCredits;
        _mainWindow.Hide();
    }

    private void OnChooseMultiplayer()
    {
        CloseMainWindow();
        _multiplayerWindow = _windowsManager.OpenWindow<MultiPlayerWindow>();
        _multiplayerWindow.StartServer += OnStartServer;
        _multiplayerWindow.JoinToServer += OnJoinToServer;
        _multiplayerWindow.Cancel += OnCancelMultiplayer;
    }

    private void CloseMultiplayerWindow()
    {
        _multiplayerWindow.StartServer -= OnStartServer;
        _multiplayerWindow.JoinToServer -= OnJoinToServer;
        _multiplayerWindow.Cancel -= OnCancelMultiplayer;
        _multiplayerWindow.Hide();
    }

    private void OnStartServer()
    {
        Debug.Log($"OnStartServer");
    }

    private void OnJoinToServer(string ip)
    {
        Debug.Log($"Multiplayer {ip}");
        CloseMultiplayerWindow();
    }

    private void OnCancelMultiplayer()
    {
        CloseMultiplayerWindow();
        OpenMainWindow();
    }

    private void OnCredits()
    {
        Debug.Log("OnCredits");
    }

    private void OnStartSingle()
    {
        Debug.Log("Single player");
        CloseMainWindow();
    }
}
