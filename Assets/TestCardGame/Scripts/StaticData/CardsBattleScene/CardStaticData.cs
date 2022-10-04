using TestCardGame.Scripts.Generally;
using UnityEngine;

namespace TestCardGame.Scripts.StaticData.CardsBattleScene
{
    [CreateAssetMenu(menuName = "Game/StaticData/CardsBattle/CardStaticData",
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