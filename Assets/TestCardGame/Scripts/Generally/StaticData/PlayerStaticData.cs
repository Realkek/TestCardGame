using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes.BattleVsZombies.Generally.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Game/PlayerStaticData",
        fileName = "PlayerStaticData")]
    public class PlayerStaticData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _moveSpeed;

        public string Name => _name;
        public int MoveSpeed => _moveSpeed;
    }
}