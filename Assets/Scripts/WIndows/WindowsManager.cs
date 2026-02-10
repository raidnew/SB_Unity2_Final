using UnityEngine;

public class WindowsManager : MonoBehaviour
{

    private BaseWindow _currentWindow;

    public virtual void Show() { }
    public virtual void Hide() { }

}
