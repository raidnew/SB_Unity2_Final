using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : BaseWindow
{
    public Action MainMenu;
    public Action Cancel;

    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _cancel;

    protected override void Init()
    {
        _mainMenu.onClick.AddListener(ClickmainMenu);
        _cancel.onClick.AddListener(ClickCancel);
    }

    private void ClickmainMenu()
    {
        MainMenu?.Invoke();
    }

    private void ClickCancel()
    {
        Cancel?.Invoke();
    }
}
