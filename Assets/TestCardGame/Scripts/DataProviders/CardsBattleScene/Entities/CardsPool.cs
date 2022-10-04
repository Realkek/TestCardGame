using TestCardGame.Scripts.StaticData.CardsBattleScene.Events;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers
{
    public class CardsPool : ObjectsPoolData
    {
        [SerializeField] private CardsPoolEventData _cardsPoolEventData;
        private const int MinimumStartCardsNumber = 4;
        private const int MaximumStartCardsNumber = 6;
        public int StartCardsCount => Random.Range(MinimumStartCardsNumber, MaximumStartCardsNumber);
        public CardsPoolEventData CardsPoolEventData => _cardsPoolEventData;
    }
}