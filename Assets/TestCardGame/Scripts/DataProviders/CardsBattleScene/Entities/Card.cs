using TestCardGame.Scripts.StaticData.CardsBattleScene.Events;
using UnityEngine;

namespace TestCardGame.Scripts.DataProviders.CardsBattleScene.Entities
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private CardsEventData _cardsEventData;
        public CardsEventData CardsEventData => _cardsEventData;
    }
}