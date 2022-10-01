using System.Collections.Generic;
using System.Linq;
using Interfaces;
using TestCardGame.Scripts.Generally;
using UnityEngine;

namespace Generally
{
    public class Bootstrapper : MonoBehaviour
    {
        private SceneData _sceneData;
        [SerializeField] private List<BaseInitializer> _baseInitializers;

        private void Awake()
        {
            _sceneData = GetComponent<SceneData>();
            _sceneData.GetComponents();

            foreach (IBaseInitializer baseInitializer in _baseInitializers)
            {
                baseInitializer.GetComponents();
                baseInitializer.Construct(_sceneData);
                baseInitializer.Initialize();
                baseInitializer.Enable();
            }
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