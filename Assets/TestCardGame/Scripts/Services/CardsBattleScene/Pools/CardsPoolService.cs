using System.Collections;
using TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace TestCardGame.Scripts.Services.CardsBattleScene.Pools
{
    [CreateAssetMenu(menuName = "Game/Services/CardsBattle/CardsPoolService",
        fileName = "CardsPoolService")]
    public class CardsPoolService : ObjectPoolService, ISubscriber, IStartable
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
                GameObject newObject = GetObject();
                yield return new WaitForSeconds(CardsSpawnInterval);
                if (newObject != null)
                {
                }
            }
        }

        public void Subscribe()
        {
            foreach (var card in GameData.CardsBattleData.Cards)
            {
                card.CardsEventData.CardSpawned += CardsEventDataOnCardSpawned;
            }

            GameData.CardsBattleData.CardsPool.CardsPoolEventData.CardsSpawnInitiated +=
                CardsPoolEventDataOnCardsSpawnInitiated;
        }

        public void Unsubscribe()
        {
            foreach (var card in GameData.CardsBattleData.Cards)
            {
                card.CardsEventData.CardSpawned -= CardsEventDataOnCardSpawned;
            }

            GameData.CardsBattleData.CardsPool.CardsPoolEventData.CardsSpawnInitiated -=
                CardsPoolEventDataOnCardsSpawnInitiated;
        }

        private void CardsPoolEventDataOnCardsSpawnInitiated()
        {
            GameData.StartCoroutine(SpawnCards());
        }

        private void CardsEventDataOnCardSpawned(GameObject obj)
        {
        }

        public void OnStart()
        {
            GameData.CardsBattleData.CardsPool.CardsPoolEventData.TriggerCardSpawnInitiated();
        }
    }
}