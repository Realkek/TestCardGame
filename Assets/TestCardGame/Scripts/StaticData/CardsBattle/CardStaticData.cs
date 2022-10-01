using TestCardGame.Scripts.Generally;
using UnityEngine;

namespace Scenes.BattleVsZombies.Generally.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Game/CardStaticData",
        fileName = "CardStaticData")]
    public class CardStaticData : BaseObjectStaticData
    {
        [SerializeField] private int _health;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _backgroundIcon;
        [SerializeField] private Sprite _hpIcon;
        [SerializeField] private Sprite _manaPointsIcon;
        [SerializeField] private Sprite _attackPointsIcon;
    }
}