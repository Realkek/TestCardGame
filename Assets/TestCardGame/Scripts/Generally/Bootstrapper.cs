using System;
using System.Collections.Generic;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace TestCardGame.Scripts.Generally
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private List<BaseInitializer> _baseInitializers;
        
        private GameData _gameData;
        private readonly List<IUpdatable> _updatableServices = new();
        private readonly List<IUpdatableFixed> _updatableFixedServices = new();
        
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
            CheckUpdatableServiceState(baseInitializer);
        }

        private void CheckUpdatableServiceState(BaseInitializer baseInitializer)
        {
            if (baseInitializer is IUpdatable updater)
                _updatableServices.Add(updater);
            if (baseInitializer is IUpdatableFixed updaterFixed)
                _updatableFixedServices.Add(updaterFixed);
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
            foreach (var updatableService in _updatableServices)
                updatableService.Operate();
        }

        private void FixedUpdate()
        {
            foreach (var updatableFixed in _updatableFixedServices)
                updatableFixed.FixedOperate();
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