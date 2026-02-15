using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Mirror.Examples.CharacterSelection
{
    public class NetMain : NetworkManager
    {
        private PlayersFactory _playersFactory;

        public struct CreateCharacterMessage : NetworkMessage
        {
            public string playerName;
        }

        [Inject]
        public void Construct(PlayersFactory playersFactory)
        {
            _playersFactory = playersFactory;
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
            ControlPlayer playerObject = _playersFactory.Create();
            Debug.Log("OnCreateCharacter");
            NetworkServer.AddPlayerForConnection(conn, playerObject.gameObject);
        }

    }
}
