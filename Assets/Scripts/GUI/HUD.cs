using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] private Button _pause;

    private PauseWindow _pauseWindow;

    private WindowsManager _windowManager;

    void Start()
    {
        _windowManager = ServiceLocator.Instance.WindowsManager;
        Init();
    }

    private void OnDestroy()
    {
        Deinit();
    }

    private void Init()
    {
        _pause.onClick.AddListener(OnPauseClick);
    }

    private void Deinit()
    {
        _pause.onClick.RemoveListener(OnPauseClick);
    }

    private void OnPauseClick()
    {
        _pauseWindow = _windowManager.OpenWindow<PauseWindow>();
        _pauseWindow.Cancel += OnCancelClick;
        _pauseWindow.MainMenu += OnMainMenuiClick;
    }

    private void OnMainMenuiClick()
    {
        ClosePauseWindow();
        ServiceLocator.Instance.Scenes.ShowMenuScene();
    }

    private void OnCancelClick()
    {
        ClosePauseWindow();
    }

    private void ClosePauseWindow()
    {
        _pauseWindow.Cancel -= OnCancelClick;
        _pauseWindow.MainMenu -= OnMainMenuiClick;
        _pauseWindow.Hide();
        _pauseWindow = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
