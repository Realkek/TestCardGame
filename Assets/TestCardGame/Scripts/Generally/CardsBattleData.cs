using System.Collections.Generic;
using System.Linq;
using TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers;
using TestCardGame.Scripts.DataProviders.CardsBattleScene.Entities;
using UnityEngine;

namespace TestCardGame.Scripts.Generally
{
    public class CardsBattleData
    {
        private CardsPool _cardsPool;
        private List<Card> _cards;

        public CardsBattleData(Component monoBehaviour)
        {
            _cardsPool = monoBehaviour.GetComponentInChildren<CardsPool>();
            _cards = monoBehaviour.GetComponentsInChildren<Card>().ToList();
        }

        public CardsPool CardsPool => _cardsPool;
        public List<Card> Cards => _cards;
    }
}