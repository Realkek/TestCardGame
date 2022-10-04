using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using TestCardGame.Scripts.Generally;
using UnityEngine;

namespace TestCardGame.Scripts.DataProviders.CardsBattleScene.Containers
{
    public class CardsTween : GameObjectDataProvider
    {
        private PathType _pathSys = PathType.Linear;
        [SerializeField] private Transform _cardTransform;
        [SerializeField] private int[] _xValues;
        private readonly Vector3[] _pathValues;
        private TweenerCore<Vector3, Path, PathOptions> _tweenerCore;

        public PathType PathSys => _pathSys;
        public Transform CardTransform => _cardTransform;
        public int[] XValues => _xValues;
        public Vector3[] PathValues => _pathValues;
    }
}