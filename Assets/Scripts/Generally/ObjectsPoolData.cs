using System.Collections.Generic;
using Generally;
using UnityEngine;

namespace Scenes.BattleVsZombies.Generally
{
    public class ObjectsPoolData : BaseInitialization
    {
        [SerializeField] private string _name;
        [SerializeField] private List<Transform> _entityPlacePositions;

        public string Name => _name;
        public List<Transform> EntityPlacePositions => _entityPlacePositions;
    }
}