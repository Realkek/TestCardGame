using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace TestCardGame.Scripts.Generally
{
    public abstract class BaseInitializer : ScriptableObject, IBaseInitializer
    {
        public abstract void Construct(GameData gameData);
    }
}