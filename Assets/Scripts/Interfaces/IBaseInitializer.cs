using System;
using Scenes.BattleVsZombies.Interfaces;
using UnityEngine;

namespace Interfaces
{
    public interface IBaseInitializer : IComponentsReceiver,  IConstructable,  IInitializer, 
        IEnabler, IStartable, IDisposable, IUpdatable, IUpdatableFixed, ISubscriber
    {
  
    }
}
