using System;

public interface IWindow
{
    public Action Close { get; set; }

    void Show();
    void Hide();
}