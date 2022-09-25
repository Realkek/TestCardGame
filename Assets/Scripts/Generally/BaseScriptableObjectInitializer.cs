using Interfaces;
using Scenes.BattleVsZombies.Generally;
using UnityEngine;

namespace Generally
{
    public class BaseScriptableObjectInitializer : ScriptableObject, IBaseInitializer
    {
        protected MonoBehaviourProvider MonoBehaviourProvider;

        public virtual void Construct(SceneData sceneData) {}
        public virtual void GetComponents() { }
        public virtual void Initialize()
        {
            MonoBehaviourProvider = FindObjectOfType<MonoBehaviourProvider>();
        }

        public virtual void Enable() => Subscribe();

        public virtual void Disable()
        {
            Unsubscribe();
        }

        public virtual void Operate()
        { }

        public virtual void FixedOperate()
        { }

        public virtual void Subscribe()
        { }

        public virtual void Unsubscribe()
        { }

        public void OnStart()
        { }

        public void Dispose()
        { }
    }
}