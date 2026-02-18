using System;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : BaseWindow
{
    public Action StartSingle;
    public Action StartMulti;
    public Action Credits;

    [SerializeField] private Button _single;
    [SerializeField] private Button _multi;
    [SerializeField] private Button _credits;

    protected override void Init()
    {
        _single.onClick.AddListener(ClickSingle);
        _multi.onClick.AddListener(ClickMulti);
        _credits.onClick.AddListener(ClickCredits);
    }

    protected override void Deinit()
    {
        _single.onClick.RemoveListener(ClickSingle);
        _multi.onClick.RemoveListener(ClickMulti);
        _credits.onClick.RemoveListener(ClickCredits);
    }

    private void ClickCredits()
    {
        Credits?.Invoke();
    }

    private void ClickMulti()
    {
        StartMulti?.Invoke();
    }

    private void ClickSingle()
    {
        StartSingle?.Invoke();
    }
}
