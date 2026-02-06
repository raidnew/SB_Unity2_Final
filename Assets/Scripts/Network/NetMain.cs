using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class NetMan : NetworkManager
{
    bool playerSpawned;
    bool playerConnected;
    private PlayersFactory _playersFactory;

    [Inject]
    public void Construct(PlayersFactory playersFactory)
    {
        _playersFactory = playersFactory;
    }

    public void OnCreateCharacter(NetworkConnectionToClient conn, PosMessage message)
    {
        GameObject go = CreatePlayer();
        NetworkServer.AddPlayerForConnection(conn, go); //присоеднияем gameObject к пулу сетевых объектов и отправляем информацию об этом остальным игрокам
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<PosMessage>(OnCreateCharacter); //указываем, какой struct должен прийти на сервер, чтобы выполнился свапн
    }

    public void ActivatePlayerSpawn()
    {
        Vector3 pos = Vector3.zero;

        PosMessage m = new PosMessage() { vector2 = pos }; //создаем struct определенного типа, чтобы сервер понял к чему эти данные относятся
        NetworkClient.Send(m); //отправка сообщения на сервер с координатами спавна
        playerSpawned = true;
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        playerConnected = true;
    }

    private void Update()
    {
        if (!playerSpawned && playerConnected)
        {
            ActivatePlayerSpawn();
        }
    }

    private GameObject CreatePlayer()
    {
        ControlPlayer player = _playersFactory.Create();
        return player.gameObject;
    }

}

public struct PosMessage : NetworkMessage //наследуемся от интерфейса NetworkMessage, чтобы система поняла какие данные упаковывать
{
    public Vector2 vector2; //нельзя использовать Property
}
