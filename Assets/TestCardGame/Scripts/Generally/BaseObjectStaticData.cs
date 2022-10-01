using UnityEngine;

namespace TestCardGame.Scripts.Generally
{
    public class BaseObjectStaticData : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;
    }
}