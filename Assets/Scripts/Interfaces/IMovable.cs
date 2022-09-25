using UnityEngine;

namespace Scenes.BattleVsZombies.Interfaces
{
    public interface IMovable
    {
        public void Move(Transform transform, Vector3 direction, float speed);
    }
}