using TestCardGame.Scripts.Generally;
using UnityEngine;

namespace TestCardGame.Scripts.StaticData.CardsBattleScene
{
    [CreateAssetMenu(menuName = "Game/StaticData/CardsBattle/CardsTweenStaticData",
        fileName = "CardsTweenStaticData")]
    public class CardsTweenStaticData : BaseObjectStaticData
    {
        [SerializeField] private float[] _xTweenInputsValues;
        [SerializeField] private int _pathNumbersCount;
        public float[] XTweenInputsValues => _xTweenInputsValues;
        public int PathNumbersCount => _pathNumbersCount;
    }
}