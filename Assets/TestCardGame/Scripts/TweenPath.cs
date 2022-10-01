using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace TestCardGame.Scripts
{
    public class TweenPath : MonoBehaviour
    {
        public Transform player;
        public PathType pathSys = PathType.Linear;
        private readonly Vector3[] _pathValues = new Vector3[7];
        public int[] xValues;

        public Vector3 playerStartPosition;
        private Vector3 playerNextPosition;
        private TweenerCore<Vector3, Path, PathOptions> _tweenerCore;

        private int indexPoint = 0;

        void Start()
        {
            player.transform.position = new Vector3(-4f, -0.8f, player.transform.position.z);
            for (int i = 0; i < _pathValues.Length; i++)
            {
                var y = -0.05f * (xValues[i] * xValues[i]);
                _pathValues[i] = new Vector3(xValues[i], y, player.transform.position.z);
            }

           
            _tweenerCore = player.transform.DOPath(_pathValues, 5, pathSys);
            _tweenerCore.SetLookAt(_pathValues[6], Vector3.right);
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