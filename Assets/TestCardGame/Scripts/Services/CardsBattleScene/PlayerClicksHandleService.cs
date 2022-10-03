using TestCardGame.Scripts.Generally;
using TestCardGame.Scripts.StaticData.CardsBattleScene.Events;
using UnityEngine;

namespace TestCardGame.Scripts.Services.CardsBattleScene
{
    [CreateAssetMenu(menuName = "Game/Services/PlayerClicksHandleService",
        fileName = "PlayerClicksHandleService")]
    public class PlayerClicksHandleService : BaseInitializer
    {
        [SerializeField] private PlayerInputKeysEventData _playerInputKeysEventData;
        private GameData _gameData;

        public override void Construct(GameData gameData)
        {
            _gameData = gameData;
        }
    }
}