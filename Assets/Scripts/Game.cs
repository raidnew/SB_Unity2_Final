using Mirror;
using Mirror.Examples.CharacterSelection;
using System;
using Unity.Netcode;
using UnityEngine;
using VContainer;

public class Game : MonoBehaviour
{

    private Scenes _scenes;
    private WindowsManager _windowsManager;
    private MainWindow _mainWindow;
    private MultiPlayerWindow _multiplayerWindow;
    private NetMain _networkManager;

    private void Start()
    {
        if(_networkManager == null)
            _networkManager = ServiceLocator.Instance.GameNetwork;
        if(_windowsManager == null)
            _windowsManager = ServiceLocator.Instance.WindowsManager;
        if(_scenes == null)
            _scenes = ServiceLocator.Instance.Scenes;
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
        _networkManager.StartHost();
        CloseMultiplayerWindow();
        _scenes.ShowlevelScene();
    }

    private void OnJoinToServer(string ip)
    {
        ip = "127.0.0.1";
        Debug.Log($"Multiplayer {ip}");
        CloseMainWindow();
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
        _networkManager.StartHost();
        _scenes.ShowlevelScene();
    }
}
