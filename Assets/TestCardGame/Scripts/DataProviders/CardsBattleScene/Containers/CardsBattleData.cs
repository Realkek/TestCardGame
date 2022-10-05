using System.Collections.Generic;
using System.Linq;
using TestCardGame.Scripts.DataProviders.CardsBattleScene.Entities;
using UnityEngine;

namespace TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers
{
    public class CardsBattleData : MonoBehaviour
    {
        private CardsPool _cardsPool;
        private List<Card> _cards;
        private CardsTween _cardsTween;

        public CardsPool CardsPool => _cardsPool ??= GetComponent<CardsPool>();
        public List<Card> Cards => _cards ??= GetComponentsInChildren<Card>().ToList();
        public CardsTween CardsTween => _cardsTween ??= _cardsTween = GetComponent<CardsTween>();
    }
}