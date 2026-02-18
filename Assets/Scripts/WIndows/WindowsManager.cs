using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    private BaseWindow _currentWindow;

    [SerializeField] private List<BaseWindow> _windowsList;

    public virtual T OpenWindow<T>(BaseWindow window) where T : BaseWindow
    {
        _currentWindow = Instantiate(window);
        _currentWindow.Close += OnCloseWindow;
        _currentWindow.transform.SetParent(transform, false);
        _currentWindow.gameObject.SetActive(true);
        _currentWindow.Show();

        Debug.Log($"Opening window: {_currentWindow}");

        return _currentWindow as T;
    }

    public virtual T OpenWindow<T>() where T : BaseWindow
    {
        BaseWindow window = _windowsList.Find(w => w.GetType() == typeof(T));
        if(window != null)
            return OpenWindow<T>(window);
        else 
            Debug.LogError($"Window of type {typeof(T)} not found in the list");   
        return null;
    }

    private void OnCloseWindow(IWindow window)
    {
        if (_currentWindow == window)
        {
            _currentWindow.Close -= OnCloseWindow;
            _currentWindow.gameObject.SetActive(false);
            _currentWindow = null;
        }
    }

}