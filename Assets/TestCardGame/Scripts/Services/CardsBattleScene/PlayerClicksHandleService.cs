using TestCardGame.Scripts.Generally;
using TestCardGame.Scripts.StaticData.Events;
using UnityEngine;

namespace Generally.Services
{
    [CreateAssetMenu(menuName = "Game/Services/PlayerClicksHandleService",
        fileName = "PlayerClicksHandleService")]
    public class PlayerClicksHandleService : BaseInitializer
    {
        [SerializeField] private PlayerInputKeysEventData _playerInputKeysEventData;
        private GameData _gameData;

        public override void Construct(GameData gameData)
        {
            base.Construct(gameData);
            _gameData = gameData;
        }

        public override void Subscribe()
        {
            base.Subscribe();
        }

        public override void Operate()
        {
            base.Operate();
        }
    }
}