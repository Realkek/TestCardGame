using TestCardGame.Scripts.Generally;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scenes.BattleVsZombies.Generally.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Game/CardStaticData",
        fileName = "CardStaticData")]
    public class CardStaticData : BaseObjectStaticData
    {
        [SerializeField] private int _health;
        [SerializeField] private string _description;
        [SerializeField] private Image _backgroundIcon;
        [SerializeField] private Image _hpIcon;
        [SerializeField] private Image _manaPointsIcon;
        [SerializeField] private Image _attackPointsIcon;
        
    }
}