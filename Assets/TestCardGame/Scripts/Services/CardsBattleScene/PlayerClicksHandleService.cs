using System.Linq;
using DG.Tweening;
using Scenes.BattleVsZombies.Generally;
using TestCardGame.Scripts.Generally;
using TestCardGame.Scripts.StaticData.Events;
using UnityEngine;

namespace Generally.Services
{
    [CreateAssetMenu(menuName = "Game/Services/PlayerClicksHandleService",
        fileName = "PlayerClicksHandleService")]
    public class PlayerClicksHandleService : BaseInitializer
    {
        [SerializeField] private PlayerInputKeysEventData _playerInputKeysEventData;
        private SceneData _sceneData;
        
        public override void Construct(SceneData sceneData)
        {
            base.Construct(sceneData);
            _sceneData = sceneData;
           
            
        }

        private void FlipCard()
        {
          var lelekek=  _sceneData.Cards.First(card => card.CardStaticData.Name == "lelkek");
        
        }

        public override void Subscribe()
        {
            
            base.Subscribe();
        }

        public override void Operate()
        {
            base.Operate();
        }
    }
}