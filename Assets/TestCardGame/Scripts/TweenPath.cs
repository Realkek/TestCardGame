using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace TestCardGame.Scripts
{
    public class TweenPath : MonoBehaviour
    {
        public Transform cardTransform;
        public PathType pathSys = PathType.Linear;
        
        private readonly Vector3[] _pathValues = new Vector3[7];
        public int[] xValues;

        public Vector3 playerStartPosition;
        private Vector3 playerNextPosition;
        private TweenerCore<Vector3, Path, PathOptions> _tweenerCore;
        
        void Start()
        {
            cardTransform.transform.position = new Vector3(-4f, -0.8f, cardTransform.transform.position.z);
            for (int i = 0; i < _pathValues.Length; i++)
            {
                var y = -0.05f * (xValues[i] * xValues[i]);
                _pathValues[i] = new Vector3(xValues[i], y, cardTransform.transform.position.z);
            }

            _tweenerCore = cardTransform.transform.DOPath(_pathValues, 5, pathSys);
            _tweenerCore.SetLookAt(_pathValues[6], Vector3.left);
            _tweenerCore.onComplete += OnTweenComplete;
            _tweenerCore.onWaypointChange += OnWaypointChange;
        }

        private void OnTweenComplete()
        {
        }

        private void OnWaypointChange(int value)
        {
        }
    }
}