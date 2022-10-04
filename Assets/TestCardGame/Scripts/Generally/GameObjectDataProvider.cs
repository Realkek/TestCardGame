using System;
using UnityEngine;

namespace TestCardGame.Scripts.Generally
{
    public class GameObjectDataProvider : MonoBehaviour
    {
        [SerializeField] private string _name;
        public string Name => _name;
        
    }
}
