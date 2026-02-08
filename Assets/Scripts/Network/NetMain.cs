using UnityEngine;

namespace Mirror.Examples.CharacterSelection
{
    public class NetMain : NetworkManager
    {
        [SerializeField] private GameObject _playersPrefab;

        public struct CreateCharacterMessage : NetworkMessage
        {
            public string playerName;
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler<CreateCharacterMessage>(OnCreateCharacter);
        }

        public override void OnClientConnect()
        {
            base.OnClientConnect();

            CreateCharacterMessage characterMessage = new CreateCharacterMessage
            {
                playerName = "1"
            };

            NetworkClient.Send(characterMessage);
        }

        void OnCreateCharacter(NetworkConnectionToClient conn, CreateCharacterMessage message)
        {
            Transform startPos = GetStartPosition();
            GameObject playerObject = Instantiate(_playersPrefab);
            NetworkServer.AddPlayerForConnection(conn, playerObject);
        }

    }
}
