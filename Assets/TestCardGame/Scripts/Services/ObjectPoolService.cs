using System.Collections.Generic;
using TestCardGame.Scripts.Generally;
using UnityEngine;

namespace Generally.Services
{
    public class ObjectPoolService : BaseInitializer
    {
        protected List<Transform> _entityPlacePositions;
        [SerializeField] private GameObject _prefab;
        private readonly Queue<GameObject> _inactiveObjects = new Queue<GameObject>();
        private readonly List<GameObject> _activeObjects = new List<GameObject>();
        private const int MaxCurrentZombiesCount = 8;
        private GameData _gameData;

        public override void Construct(GameData gameData)
        {
            base.Construct(gameData);
            _gameData = gameData;
        }

        protected GameObject Get()
        {
            if ((_inactiveObjects.Count + _activeObjects.Count) < MaxCurrentZombiesCount)
                AddObjects();
            GameObject activeObject = _inactiveObjects.Dequeue();
            ActivateGameObject(activeObject);
            _activeObjects.Add(activeObject);
            return activeObject;
        }

        private void AddObjects()
        {
            int randomPlaceNumber = Random.Range(0, _entityPlacePositions.Count);
            var newObject = Instantiate(_prefab, _entityPlacePositions[randomPlaceNumber].position, Quaternion.identity,
                _entityPlacePositions[randomPlaceNumber]);
            _inactiveObjects.Enqueue(newObject);
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