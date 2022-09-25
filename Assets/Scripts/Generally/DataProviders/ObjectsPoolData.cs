using System.Collections.Generic;
using UnityEngine;

namespace Generally.DataProviders
{
    public class ObjectsPoolData : GameObjectDataProvider
    {
        [SerializeField] private List<Transform> _entityPlacePositions;
        public List<Transform> EntityPlacePositions => _entityPlacePositions;
    }
}