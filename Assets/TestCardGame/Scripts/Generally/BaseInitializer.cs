using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace TestCardGame.Scripts.Generally
{
    public abstract class BaseInitializer : ScriptableObject, IBaseInitializer
    {
        public virtual void Construct(GameData gameData) {}
        public virtual void GetComponents() { }
        public virtual void Initialize(){}
        

        public virtual void Enable() => Subscribe();

        public virtual void Disable() => Unsubscribe(); 

        public virtual void Operate() { }

        public virtual void FixedOperate() { }

        public virtual void Subscribe() { }

        public virtual void Unsubscribe()
        { }

        public void OnStart()
        { }

        public void Dispose()
        { }
    }
}