using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IShooter
    {
        Vector3 barrel { get; }
        Vector3 shootDirection { get; }
    }
}
