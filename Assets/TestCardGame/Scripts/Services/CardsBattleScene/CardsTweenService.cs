using TestCardGame.Scripts.Generally;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using TestCardGame.Scripts.StaticData.CardsBattleScene.Events;
using UnityEngine;

namespace TestCardGame.Scripts.Services.CardsBattleScene
{ 
    [CreateAssetMenu(menuName = "Game/Services/CardsBattle/CardsTweenService",
        fileName = "CardsTweenService")]
    public class CardsTweenService : BaseInitializer, IInitializer, ISubscriber
    {
        private GameData _gameData;
        private CardsEventData _cardsEventData;

        public override void Construct(GameData gameData)
        {
            _gameData = gameData;
        }

        public void Initialize()
        {
            foreach (var card in _gameData.CardsBattleData.Cards) _cardsEventData = card.CardsEventData;
        }

        public void Subscribe()
        {
            _cardsEventData.CardSpawned += CardsEventDataOnCardSpawned;
        }

        public void Unsubscribe()
        {
            _cardsEventData.CardSpawned -= CardsEventDataOnCardSpawned;
        }

        private void CardsEventDataOnCardSpawned(GameObject gameObject)
        {
            Debug.Log("kek");
        }
    }
}