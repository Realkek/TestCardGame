using TestCardGame.Scripts.Generally;
using TestCardGame.Scripts.StaticData.CardsBattleScene.Events;
using UnityEngine;

namespace TestCardGame.Scripts.DataProviders.CardsBattleScene.Entities
{
    public class Card : GameObjectDataProvider
    {
        [SerializeField] private CardsEventData _cardsEventData;
        public CardsEventData CardsEventData => _cardsEventData;
    }
}