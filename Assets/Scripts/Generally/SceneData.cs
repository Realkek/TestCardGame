using System.Collections.Generic;
using System.Linq;
using Generally.DataProviders;
using Interfaces;
using UnityEngine;

namespace Generally
{
    public class SceneData : MonoBehaviour, IComponentsReceiver
    {
        private List<ObjectsPoolData> _objectPools;

        public  void GetComponents()
        {
            _objectPools = GetComponentsInChildren<ObjectsPoolData>().ToList();
        }
        
        public List<ObjectsPoolData> ObjectPools => _objectPools;
    }
}