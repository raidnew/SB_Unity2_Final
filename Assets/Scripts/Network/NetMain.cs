using Assets.Scripts.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Mirror.Examples.CharacterSelection
{
    public class NetMain : NetworkManager
    {
        private PlayersFactory _playersFactory;
        [SerializeField] private GameObject _bulletPrefab;

        public struct CreateCharacterMessage : NetworkMessage
        {
            public string playerName;
        }

        public struct CharacterShootMessage : NetworkMessage
        {
            public Vector3 barrel;
            public Vector3 direction;
        }

        [Inject]
        public void Construct(PlayersFactory playersFactory)
        {
            _playersFactory = playersFactory;
        }

        private void OnDestroy()
        {
            Debug.Log("OnDestroy");
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler<CreateCharacterMessage>(OnCreateCharacter);
            NetworkServer.RegisterHandler<CharacterShootMessage>(OnCharacterShoot);
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

        public void Shoot(IShooter shooter)
        {
            CharacterShootMessage shootMessage = new CharacterShootMessage
            {
                barrel = shooter.barrel,
                direction = shooter.shootDirection
            };
            NetworkClient.Send(shootMessage);
        }

        void OnCreateCharacter(NetworkConnectionToClient conn, CreateCharacterMessage message)
        {
            Transform startPos = GetStartPosition();
            ControlPlayer playerObject = _playersFactory.Create();
            NetworkServer.AddPlayerForConnection(conn, playerObject.gameObject);
        }

        private void OnCharacterShoot(NetworkConnectionToClient conn, CharacterShootMessage message)
        {
            GameObject test = Instantiate(_bulletPrefab, message.barrel, Quaternion.LookRotation(message.direction));
            //IBullet bullet = test.GetComponent<IBullet>();
            //bullet.Direction(message.barrel, message.direction);
            NetworkServer.Spawn(test, conn);
        }

    }
}
