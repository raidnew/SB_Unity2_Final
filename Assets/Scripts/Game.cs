using Mirror;
using System;
using UnityEngine;
using VContainer;

public class Game : MonoBehaviour
{

    [SerializeField] private Scenes _scenes;

    private WindowsManager _windowsManager;
    private MainWindow _mainWindow;
    private MultiPlayerWindow _multiplayerWindow;
    private NetworkManager _networkManager;

    private void Start()
    {
        if(_networkManager == null)
            _networkManager = NetworkManager.singleton;
        if(_windowsManager == null)
            _windowsManager = ServiceLocator.Instance.WindowsManager;
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
        _networkManager.StartServer();
        CloseMultiplayerWindow();
        _scenes.ShowlevelScene();
    }

    private void OnJoinToServer(string ip)
    {
        Debug.Log($"Multiplayer {ip}");
        CloseMultiplayerWindow();
        _networkManager.networkAddress = ip;
        _networkManager.StartClient();
        CloseMultiplayerWindow();
        _scenes.ShowlevelScene();
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
        _scenes.ShowlevelScene();
    }
}
