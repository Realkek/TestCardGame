using System.Collections.Generic;
using TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers;
using TestCardGame.Scripts.Generally;
using UnityEngine;

namespace TestCardGame.Scripts.Services
{
    public class ObjectPoolService : BaseInitializer
    {
        protected List<Transform> EntityPlacePositions;
        protected GameData GameData;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int maxCurrentObjectsCount;
        private readonly Queue<GameObject> _inactiveObjects = new Queue<GameObject>();
        private readonly List<GameObject> _activeObjects = new List<GameObject>();

        public override void Construct(GameData gameData)
        {
            GameData = gameData;
        }

        protected GameObject GetObject()
        {
            if ((_inactiveObjects.Count + _activeObjects.Count) < maxCurrentObjectsCount)
                AddObjects();
            GameObject activeObject = _inactiveObjects.Dequeue();
            _activeObjects.Add(activeObject);
            ActivateGameObject(activeObject);
            return activeObject;
        }

        private void AddObjects()
        {
            int chosenPositionNumber = ChooseNewObjectInstancePositionNumber();
            var newObject = Instantiate(_prefab, EntityPlacePositions[chosenPositionNumber].position,
                Quaternion.identity,
                EntityPlacePositions[chosenPositionNumber]);
            _inactiveObjects.Enqueue(newObject);
        }

        protected virtual int ChooseNewObjectInstancePositionNumber()
        {
            return Random.Range(0, EntityPlacePositions.Count);
        }


        private void ReturnToPool(GameObject objectToReturn)
        {
            DeactivateGameObject(objectToReturn);
            _inactiveObjects.Enqueue(objectToReturn);
            _activeObjects.Remove(objectToReturn);
        }

        private void ActivateGameObject(GameObject genericGameObject) => genericGameObject.SetActive(true);
        private void DeactivateGameObject(GameObject genericGameObject) => genericGameObject.SetActive(false);
    }
}