using System;

namespace TestCardGame.Scripts.Interfaces.BaseInitialization
{
    public interface IBaseInitializer : IComponentsReceiver,  IConstructable,  IInitializer, 
        IEnabler, IStartable, IDisposable, IUpdatable, IUpdatableFixed, ISubscriber { }
}
