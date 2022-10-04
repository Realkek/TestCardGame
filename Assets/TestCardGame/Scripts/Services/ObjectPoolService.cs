using System.Collections.Generic;
using TestCardGame.Scripts.Generally;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using Unity.VisualScripting;
using UnityEngine;

namespace TestCardGame.Scripts.Services
{
    public class ObjectPoolService : BaseInitializer, IInitializer
    {
        protected List<Transform> EntityPlacePositions;
        protected GameData GameData;
        protected int MaxCurrentObjectsCount;
        [SerializeField] private GameObject _prefab;

        private readonly Queue<GameObject> _inactiveObjects = new Queue<GameObject>();
        private readonly List<GameObject> _activeObjects = new List<GameObject>();

        public override void Construct(GameData gameData)
        {
            GameData = gameData;
        }

        public virtual void Initialize()
        {
            EntityPlacePositions = GameData.CardsBattleData.CardsPool.EntityPlacePositions;
        }

        protected GameObject GetObject()
        {
            if ((_inactiveObjects.Count + _activeObjects.Count) < MaxCurrentObjectsCount)
                AddObjects();
            if (_inactiveObjects.Count > 0)
            {
                GameObject activeObject = _inactiveObjects?.Dequeue();
                _activeObjects.Add(activeObject);
                ActivateGameObject(activeObject);
                return activeObject;
            }

            return null;
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