using System;
using Interfaces;
using Scenes.BattleVsZombies.Interfaces;
using UnityEngine;

namespace Generally
{
    public abstract class BaseInitialization : MonoBehaviour, IBaseInitializer
    {
        public virtual void GetComponents() { }
        public virtual void Construct(SceneData sceneData){}
        public virtual void Initialize(){}
        public virtual void Enable() => Subscribe();
        public virtual void OnStart() {}
        public virtual void Disable() => Unsubscribe();
        public virtual void Dispose() {}
        public virtual void Operate(){}
        public virtual void FixedOperate(){}
        public virtual void Subscribe() { }
        public virtual void Unsubscribe() { }
        
    }
}
