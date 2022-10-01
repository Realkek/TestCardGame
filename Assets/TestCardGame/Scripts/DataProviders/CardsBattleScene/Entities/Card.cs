using Scenes.BattleVsZombies.Generally.StaticData;
using UnityEngine;

namespace TestCardGame.Scripts.DataProviders.CardsBattleScene.Entities
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private CardStaticData _cardStaticData;
        public CardStaticData CardStaticData => _cardStaticData;
    }
}