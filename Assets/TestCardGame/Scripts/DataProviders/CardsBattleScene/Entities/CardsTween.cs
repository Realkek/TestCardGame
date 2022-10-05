using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using TestCardGame.Scripts.Generally;
using TestCardGame.Scripts.StaticData.CardsBattleScene;
using UnityEngine;

namespace TestCardGame.Scripts.DataProviders.CardsBattleScene.Entities
{
    public class CardsTween : GameObjectDataProvider
    {
        [SerializeField] private CardStaticData _cardStaticData;
        [SerializeField] private CardsTweenStaticData _cardsTweenStaticData;
        private PathType _pathType = PathType.Linear;
        private Vector3[] _pathValues;
        private TweenerCore<Vector3, Path, PathOptions> _tweenerCore;
        private float[] _xTweenInputValues;
        private Transform _cardTransform;

        public PathType PathType => _pathType;
        
        public Vector3[] PathValues
        {
            get
            {
                _pathValues = new Vector3[_cardsTweenStaticData.PathNumbersCount];
                return _pathValues;
            }
        }

        public float[] XTweenInputValues
        {
            get
            {
                _xTweenInputValues = _cardsTweenStaticData.XTweenInputsValues;
                return _xTweenInputValues;
            }
        }
    }
}