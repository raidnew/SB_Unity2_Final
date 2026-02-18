using System;

public interface IWindow
{
    public Action<IWindow> Close { get; set; }

    void Show();
    void Hide();
}