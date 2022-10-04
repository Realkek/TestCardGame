using System.Collections;
using TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace TestCardGame.Scripts.Services.CardsBattleScene.Pools
{
    [CreateAssetMenu(menuName = "Game/Services/CardsBattle/CardsPoolService",
        fileName = "CardsPoolService")]
    public class CardsPoolService : ObjectPoolService, ISubscriber
    {
        private CardsPool _cardsPool;
        private const int FirstPositionNumber = 0;
        private const float CardsSpawnInterval = 0.4f;

        public override void Initialize()
        {
            base.Initialize();
            MaxCurrentObjectsCount = GameData.CardsBattleData.CardsPool.StartCardsCount;
        }

        protected override int ChooseNewObjectInstancePositionNumber()
        {
            base.ChooseNewObjectInstancePositionNumber();
            return FirstPositionNumber;
        }

        private IEnumerator SpawnCards()
        {
            while (true)
            {
                GetObject();
                yield return new WaitForSeconds(CardsSpawnInterval);
            }
        }

        public void Subscribe()
        {
            foreach (var card in GameData.CardsBattleData.Cards)
            {
                card.CardsEventData.CardSpawnInitiated += CardsEventDataOnCardSpawnInitiated;
            }
        }

        public void Unsubscribe()
        {
            foreach (var card in GameData.CardsBattleData.Cards)
            {
                card.CardsEventData.CardSpawnInitiated -= CardsEventDataOnCardSpawnInitiated;
            }
        }

        private void CardsEventDataOnCardSpawnInitiated()
        {
            GameData.StartCoroutine(SpawnCards());
        }
    }
}