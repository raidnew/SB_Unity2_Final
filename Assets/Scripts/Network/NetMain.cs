using Mirror;
using Mirror.BouncyCastle.Asn1.Cmp;
using UnityEngine;

public class NetMain : NetworkManager
{
    public override void OnClientConnect()
    {
        Debug.Log("Client Connected");
    }

    public override void OnStartServer()
    {
        Debug.Log("Server Started");
        base.OnStartServer();
        NetworkServer.RegisterHandler<PosMessage>(OnCreateCharacter); //указываем, какой struct должен прийти на сервер, чтобы выполнился свапн
    }

    public void OnCreateCharacter(NetworkConnectionToClient conn, PosMessage message)
    {
        /*
        GameObject go = Instantiate(playerPrefab, message.vector2, Quaternion.identity); //локально на сервере создаем gameObject
        NetworkServer.AddPlayerForConnection(conn, go); //присоеднияем gameObject к пулу сетевых объектов и отправляем информацию об этом остальным игрокам
        */
        Debug.Log("OnCreateCharacter");
    }
}

public struct PosMessage : NetworkMessage //наследуемся от интерфейса NetworkMessage, чтобы система поняла какие данные упаковывать
{
    public Vector2 vector2; //нельзя использовать Property
}