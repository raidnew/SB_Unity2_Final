using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    private BaseWindow _currentWindow;

    [SerializeField] private List<WindowData> _windowsList;

    public virtual void OpenWindow(BaseWindow window)
    {
        Debug.Log($"Opening window: {window.name}");

        _currentWindow = Instantiate(window);
        _currentWindow.Close += OnCloseWindow;
        _currentWindow.transform.SetParent(transform, false);
        _currentWindow.gameObject.SetActive(true);
    }

    public virtual void OpenWindow(Window windowType)
    {
        BaseWindow window = _windowsList.Find(w => w.type == windowType).windowPrefab;
        if(window != null)
            OpenWindow(window);
        else 
            Debug.LogError($"Window of type {windowType} not found in the list");   
    }

    public virtual void CloseWindow() 
    { 
        if(_currentWindow != null)
            _currentWindow.Hide();
    }

    private void OnCloseWindow()
    {
        CloseWindow();
    }

}

public enum Window
{
    Main
}

[Serializable]
public struct WindowData
{
    public Window type;
    public BaseWindow windowPrefab; 
}