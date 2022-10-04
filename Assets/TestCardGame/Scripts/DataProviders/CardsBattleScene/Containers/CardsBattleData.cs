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

        public CardsPool CardsPool
        {
            get
            {
                _cardsPool = GetComponent<CardsPool>();
                return _cardsPool;
            }
        }

        public List<Card> Cards
        {
            get
            {
                _cards = GetComponentsInChildren<Card>().ToList();
                return _cards;
            }
        }

        public CardsTween CardsTween
        {
            get
            {
                _cardsTween = GetComponent<CardsTween>();
                return _cardsTween;
            }
        }
    }
}