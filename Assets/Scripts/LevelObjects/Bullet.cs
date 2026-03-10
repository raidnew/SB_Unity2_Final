using Assets.Scripts.Interfaces;
using Mirror;
using Unity.Netcode.Components;
using UnityEngine;

public class Bullet : NetworkBehaviour, IBullet
{
    private NetworkRigidbody _rigitBody;

    public void Direction(Vector3 position, Vector3 direction)
    {
        transform.position = position;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigitBody = GetComponent<NetworkRigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
