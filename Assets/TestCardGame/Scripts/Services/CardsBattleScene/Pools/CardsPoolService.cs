using System.Collections;
using TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using TestCardGame.Scripts.StaticData.CardsBattleScene.Events;
using UnityEngine;

namespace TestCardGame.Scripts.Services.CardsBattleScene.Pools
{
    [CreateAssetMenu(menuName = "Game/Services/CardsBattle/CardsPoolService",
        fileName = "CardsPoolService")]
    public class CardsPoolService : ObjectPoolService, ISubscriber, IStartable
    {
        [SerializeField] private CardsEventData _cardsEventData;

        private CardsPool _cardsPool;
        private const int FirstPositionNumber = 0;
        private const float CardsSpawnInterval = 0.4f;

        public override void Initialize()
        {
            base.Initialize();
            _cardsPool = GameData.CardsBattleData.CardsPool;
            MaxCurrentObjectsCount = _cardsPool.StartCardsCount;
        }

        protected override int ChooseNewObjectInstancePositionNumber()
        {
            base.ChooseNewObjectInstancePositionNumber();
            return FirstPositionNumber;
        }

        private IEnumerator SpawnCards()
        {
            int spawnedCardsCount = 0;
            while (spawnedCardsCount < _cardsPool.StartCardsCount)
            {
                GameObject newObject = GetObject();
                spawnedCardsCount++;
                if (newObject != null)
                    _cardsEventData.TriggerCardSpawned(newObject);
                yield return new WaitForSeconds(CardsSpawnInterval);
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