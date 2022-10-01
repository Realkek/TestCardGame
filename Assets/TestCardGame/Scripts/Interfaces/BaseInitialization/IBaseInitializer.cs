using System;
using Scenes.BattleVsZombies.Interfaces;

namespace Interfaces
{
    public interface IBaseInitializer : IComponentsReceiver,  IConstructable,  IInitializer, 
        IEnabler, IStartable, IDisposable, IUpdatable, IUpdatableFixed, ISubscriber { }
}
