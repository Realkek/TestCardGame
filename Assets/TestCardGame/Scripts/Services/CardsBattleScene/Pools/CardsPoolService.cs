using System.Collections;
using TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers;
using UnityEngine;

namespace TestCardGame.Scripts.Services.CardsBattleScene.Pools
{
    [CreateAssetMenu(menuName = "Game/Services/CardsBattle/CardsPoolService",
        fileName = "CardsPoolService")]
    public class CardsPoolService : ObjectPoolService
    {
        private CardsPool _cardsPool;
        private const int FirstPositionNumber = 0;

        public override void Initialize()
        {
            base.Initialize();
            _cardsPool = GameData.CardsBattleData.CardsPool;
        }

        public override void Enable()
        {
            base.Enable();
        }

        public override void Disable()
        {
            base.Disable();
        }

        public override void Subscribe()
        {
            base.Subscribe();
        }

        public override void Unsubscribe()
        {
            base.Unsubscribe();
        }

        protected override int ChooseNewObjectInstancePositionNumber()
        {
            base.ChooseNewObjectInstancePositionNumber();
            return FirstPositionNumber;
        }

        private IEnumerator SpawnCards()
        {
            GetObject();
            yield return new WaitForSeconds(0.4f);
        }
    }
}