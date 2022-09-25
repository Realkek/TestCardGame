using UnityEngine;

namespace Generally
{
    public class GameObjectDataProvider : MonoBehaviour
    {
        [SerializeField] private string _name;
        public string Name => _name;
    }
}
