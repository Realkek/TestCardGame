using Scenes.BattleVsZombies.Generally;
using UnityEngine;

namespace Generally
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private ServicesInitializer _servicesInitializer;

        private void Awake()
        {
            _servicesInitializer.GetComponents();
            _servicesInitializer.Construct(_sceneData);
            _servicesInitializer.Initialize();
            _servicesInitializer.Enable();
        }

        private void Update()
        {
            _servicesInitializer.Operate();
        }

        private void FixedUpdate()
        {
            _servicesInitializer.FixedOperate();
        }

        private void OnDestroy()
        {
            _servicesInitializer.Dispose();
        }
    }
}