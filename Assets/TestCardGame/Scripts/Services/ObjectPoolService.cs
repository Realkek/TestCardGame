using System.Collections.Generic;
using Scenes.BattleVsZombies.Generally;
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
        private SceneData _sceneData;

        public override void Construct(SceneData sceneData)
        {
            base.Construct(sceneData);
            _sceneData = sceneData;
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