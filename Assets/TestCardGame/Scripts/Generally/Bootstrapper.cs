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
            InitializeBase();
        }

        private void InitializeBase()
        {
            foreach (var baseInitializer in _baseInitializers)
            {
                GetComponents(baseInitializer);
                baseInitializer.Construct(_gameData);
                Initialize(baseInitializer);
            }
        }

        private void GetComponents(BaseInitializer baseInitializer)
        {
            if (baseInitializer is IComponentsReceiver componentsReceiver)
                componentsReceiver.GetComponents();
        }

        private void Initialize(BaseInitializer baseInitializer)
        {
            if (baseInitializer is IInitializer initializer)
                initializer.Initialize();
        }

        private void Start()
        {
            foreach (var baseInitializer in _baseInitializers)
                if (baseInitializer is IStartable initializer)
                    initializer.OnStart();
        }

        private void OnEnable()
        {
            foreach (var baseInitializer in _baseInitializers)
            {
                if (baseInitializer is IEnabler enabler) enabler.Enable();
                if (baseInitializer is ISubscriber subscriber) subscriber.Subscribe();
            }
        }

        private void Update()
        {
            foreach (var baseInitializer in _baseInitializers)
                if (baseInitializer is IUpdatable updater)
                    updater.Operate();
        }

        private void FixedUpdate()
        {
            foreach (var baseInitializer in _baseInitializers)
                if (baseInitializer is IUpdatableFixed updaterFixed)
                    updaterFixed.FixedOperate();
        }

        private void OnDisable()
        {
            foreach (var baseInitializer in _baseInitializers)
            {
                if (baseInitializer is IEnabler disabler) disabler.Disable();
                if (baseInitializer is ISubscriber subscriber) subscriber.Unsubscribe();
            }
        }

        private void OnDestroy()
        {
            foreach (var baseInitializer in _baseInitializers)
                if (baseInitializer is IDisposable disposer)
                    disposer.Dispose();
        }
    }
}