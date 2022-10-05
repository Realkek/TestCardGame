using TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace TestCardGame.Scripts.Generally
{
    public class GameData : MonoBehaviour
    {
        [SerializeField] private CardsBattleData _cardsBattleData;
        
        public CardsBattleData CardsBattleData => _cardsBattleData;
    }
}