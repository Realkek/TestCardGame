using Scenes.BattleVsZombies.Generally.StaticData;
using TestCardGame.Scripts.Generally;
using Unity.VisualScripting;
using UnityEngine;

namespace TestCardGame.Scripts.DataProviders.CardsBattleScene.Entities
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private CardStaticData _cardStaticData;
        

        public CardStaticData CardStaticData => _cardStaticData;
        
    }
}