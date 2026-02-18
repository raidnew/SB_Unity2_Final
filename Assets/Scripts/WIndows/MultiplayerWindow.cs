using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayerWindow : BaseWindow
{
    public Action<string> JoinToServer;
    public Action StartServer;
    public Action Cancel;

    [SerializeField] private Button _start;
    [SerializeField] private Button _join;
    [SerializeField] private Button _cancel;
    [SerializeField] private TextMeshProUGUI _ip1;
    [SerializeField] private TextMeshProUGUI _ip2;
    [SerializeField] private TextMeshProUGUI _ip3;
    [SerializeField] private TextMeshProUGUI _ip4;

    protected override void Init()
    {
        _start.onClick.AddListener(ClickStart);
        _join.onClick.AddListener(ClickJoin);
        _cancel.onClick.AddListener(ClickCancel);
    }

    private void ClickStart()
    {
        StartServer?.Invoke();
    }

    private void ClickCancel()
    {
        Cancel?.Invoke();
    }

    private void ClickJoin()
    {
        string ip = $"{_ip1.text}.{_ip2.text}.{_ip3.text}.{_ip4.text}";
        JoinToServer?.Invoke(ip);
    }
}
