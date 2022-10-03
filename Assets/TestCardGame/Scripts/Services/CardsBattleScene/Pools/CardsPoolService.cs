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