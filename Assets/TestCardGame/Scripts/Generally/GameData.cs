using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace TestCardGame.Scripts.Generally
{
    public class GameData : MonoBehaviour, IComponentsReceiver
    {
        private CardsBattleData _cardsBattleData;

        public void GetComponents()
        {
            _cardsBattleData = new CardsBattleData();
        }

        public CardsBattleData CardsBattleData => _cardsBattleData;
    }
}