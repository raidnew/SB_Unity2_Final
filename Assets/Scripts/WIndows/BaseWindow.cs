using System;
using UnityEngine;

public class BaseWindow : MonoBehaviour, IWindow
{
    public Action<IWindow> Close { get; set; }

    public void Hide()
    {
        Deinit();
        Close?.Invoke(this);
    }

    public void Show()
    {
        Init();
    }

    protected virtual void Init()
    {

    }

    protected virtual void Deinit()
    {

    }
}
