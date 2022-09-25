using System.Collections.Generic;
using Scenes.BattleVsZombies.Generally;
using UnityEngine;

namespace Generally
{
    public class ServicesInitializer : BaseInitialization
    {
        [SerializeField] private List<BaseScriptableObjectInitializer> _baseScriptableObjectInitializers;
        [SerializeField] private List<BaseInitialization> _baseInitializers;

        private SceneData _sceneData;

        public override void GetComponents()
        {
            GetComponentsScriptableObjectServices();
            GetComponentsServices();
        }

        public override void Construct(SceneData sceneData)
        {
            base.Construct(sceneData);
            _sceneData = sceneData;
            ConstructScriptableObjectServices();
            ConstructServices();
        }

        public override void Initialize()
        {
            InitializeScriptableObjectServices();
            InitializeServices();
        }

        public override void Enable()
        {
            EnableScriptableObjectServices();
            EnableServices();
        }

        public override void Operate()
        {
            OperateScriptableObjectBaseServices();
            OperateBaseServices();
        }

        private void GetComponentsScriptableObjectServices()
        {
            foreach (var baseScriptableObjectInitializer in _baseScriptableObjectInitializers)
            {
                baseScriptableObjectInitializer.GetComponents();
            }
        }

        private void GetComponentsServices()
        {
            foreach (var baseInitializer in _baseInitializers)
            {
                baseInitializer.GetComponents();
            }
        }

        private void ConstructScriptableObjectServices()
        {
            foreach (var baseScriptableObjectInitializer in _baseScriptableObjectInitializers)
            {
                baseScriptableObjectInitializer.Construct(_sceneData);
            }
        }

        private void ConstructServices()
        {
            foreach (var baseInitializer in _baseInitializers)
            {
                baseInitializer.Construct(_sceneData);
            }
        }

        private void InitializeScriptableObjectServices()
        {
            foreach (var baseScriptableObjectInitializer in _baseScriptableObjectInitializers)
            {
                baseScriptableObjectInitializer.Initialize();
            }
        }

        private void InitializeServices()
        {
            foreach (var baseInitializer in _baseInitializers)
            {
                baseInitializer.Initialize();
            }
        }


        private void EnableScriptableObjectServices()
        {
            foreach (var baseScriptableObjectInitializer in _baseScriptableObjectInitializers)
            {
                baseScriptableObjectInitializer.Enable();
            }
        }

        private void EnableServices()
        {
            foreach (var baseInitialization in _baseInitializers)
            {
                baseInitialization.Enable();
            }
        }

        private void OperateScriptableObjectBaseServices()
        {
            foreach (var baseScriptableObjectInitializer in _baseScriptableObjectInitializers)
            {
                baseScriptableObjectInitializer.Operate();
            }
        }

        private void OperateBaseServices()
        {
            foreach (var baseInitializer in _baseInitializers)
            {
                baseInitializer.Operate();
            }
        }
    }
}