using Assets.Scripts.Interfaces;
using Mirror;
using Unity.Netcode.Components;
using UnityEngine;

public class Bullet : NetworkBehaviour//, IBullet
{
    [SerializeField] private Rigidbody _rigitBody;
    private float destroyAfter = 2f;

    public override void OnStartServer()
    {
        Invoke(nameof(DestroySelf), destroyAfter);
    }

    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }

    void Start()
    {
        Debug.Log("AAAAAAAAA");
        _rigitBody.AddForce(transform.forward * 1000f);
    }

}
