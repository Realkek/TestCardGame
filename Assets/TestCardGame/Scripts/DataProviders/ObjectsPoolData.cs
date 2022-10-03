using System.Collections.Generic;
using TestCardGame.Scripts.Generally;
using UnityEngine;

namespace TestCardGame.Scripts.DataProviders
{
    public class ObjectsPoolData : GameObjectDataProvider
    {
        [SerializeField] private List<Transform> _entityPlacePositions;
        public List<Transform> EntityPlacePositions => _entityPlacePositions;
    }
}