using System;
using System.Collections.Generic;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace TestCardGame.Scripts.Generally
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

        private void Start()
        {
            foreach (IStartable baseInitializer in _baseInitializers)
                baseInitializer.OnStart();
        }

        private void OnEnable()
        {
            foreach (IEnabler baseInitializer in _baseInitializers)
                baseInitializer.Enable();
        }

        private void Update()
        {
            foreach (IUpdatable baseInitializer in _baseInitializers) baseInitializer.Operate();
        }

        private void FixedUpdate()
        {
            foreach (IUpdatableFixed baseInitializer in _baseInitializers) baseInitializer.FixedOperate();
        }

        private void OnDestroy()
        {
            foreach (IDisposable baseInitializer in _baseInitializers) baseInitializer.Dispose();
        }
    }
}