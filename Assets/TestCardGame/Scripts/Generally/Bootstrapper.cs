using System.Collections.Generic;
using TestCardGame.Scripts.Generally;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace Generally
{
    public class Bootstrapper : MonoBehaviour
    {
        private GameData _gameData;
        [SerializeField] private List<BaseInitializer> _baseInitializers;

        private void Awake()
        {
            _gameData = GetComponent<GameData>();
            _gameData.GetComponents();

            foreach (IBaseInitializer baseInitializer in _baseInitializers)
            {
                baseInitializer.GetComponents();
                baseInitializer.Construct(_gameData);
                baseInitializer.Initialize();
            }
        }

        private void OnEnable()
        {
            foreach (IBaseInitializer baseInitializer in _baseInitializers)
                baseInitializer.Enable();
        }

        private void Update()
        {
            foreach (IBaseInitializer baseInitializer in _baseInitializers) baseInitializer.Operate();
        }

        private void FixedUpdate()
        {
            foreach (IBaseInitializer baseInitializer in _baseInitializers) baseInitializer.FixedOperate();
        }

        private void OnDestroy()
        {
            foreach (IBaseInitializer baseInitializer in _baseInitializers) baseInitializer.Dispose();
        }
    }
}