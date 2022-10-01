using System.Collections.Generic;
using System.Linq;
using Generally.DataProviders;
using Interfaces;
using TestCardGame.Scripts.DataProviders.CardsBattleScene.Entities;
using UnityEngine;

namespace Generally
{
    public class SceneData : MonoBehaviour, IComponentsReceiver
    {
        private List<ObjectsPoolData> _objectPools;
        private List<Card> _cards;

        public void GetComponents()
        {
            _objectPools = GetComponentsInChildren<ObjectsPoolData>().ToList();
            _cards = GetComponentsInChildren<Card>().ToList();
        }

        public List<ObjectsPoolData> ObjectPools => _objectPools;
        public List<Card> Cards => _cards;
    }
}