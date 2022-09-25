using System.Collections.Generic;
using System.Linq;
using Scenes.BattleVsZombies.Generally;

namespace Generally
{
    public class SceneData : BaseInitialization
    {
        private List<ObjectsPoolData> _objectPools;

        public override void GetComponents()
        {
            base.GetComponents();
            _objectPools = GetComponentsInChildren<ObjectsPoolData>().ToList();

            foreach (var objectPool in _objectPools)
            {
                objectPool.GetComponents();
            }
        }
        
        public List<ObjectsPoolData> ObjectPools => _objectPools;
    }
}