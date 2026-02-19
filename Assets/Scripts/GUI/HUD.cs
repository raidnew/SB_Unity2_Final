using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] private Button _pause;

    private WindowsManager _windowManager;

    void Start()
    {
        _windowManager = ServiceLocator.Instance.WindowsManager;
        _pause.onClick.AddListener(OnPauseClick);
    }

    private void OnPauseClick()
    {
        Debug.Log("OnPauseClick");
        _windowManager.OpenWindow<PauseWindow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
