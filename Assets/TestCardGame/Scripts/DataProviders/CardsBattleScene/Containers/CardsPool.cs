using TestCardGame.Scripts.StaticData.CardsBattleScene.Events;
using TestCardGame.Scripts.StaticData.Events;
using UnityEngine;

namespace TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers
{
    public class CardsPool : ObjectsPoolData
    {
        private const int MinimumStartCardsNumber = 4;
        private const int MaximumStartCardsNumber = 6;

        public int StartCardsCount => Random.Range(MinimumStartCardsNumber, MaximumStartCardsNumber);
    }
}