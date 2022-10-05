using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TestCardGame.Scripts.Generally;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using TestCardGame.Scripts.StaticData.CardsBattleScene.Events;
using UnityEngine;
using Path = DG.Tweening.Plugins.Core.PathCore.Path;

namespace TestCardGame.Scripts.Services.CardsBattleScene
{
    [CreateAssetMenu(menuName = "Game/Services/CardsBattle/CardsTweenService",
        fileName = "CardsTweenService")]
    public class CardsTweenService : BaseInitializer, IInitializer, ISubscriber
    {
        private GameData _gameData;
        private CardsEventData _cardsEventData;
        private Vector3[] _pathValues;
        private Transform _cardTransform;
        private float[] _xValues;
        private PathType _pathType;
        private TweenerCore<Vector3, Path, PathOptions> _tweenerCore;

        public override void Construct(GameData gameData)
        {
            _gameData = gameData;
        }

        public void Initialize()
        {
            foreach (var card in _gameData.CardsBattleData.Cards) _cardsEventData = card.CardsEventData;
            _xValues = _gameData.CardsBattleData.CardsTween.XTweenInputValues;
            _pathType = _gameData.CardsBattleData.CardsTween.PathType;
            _pathValues = _gameData.CardsBattleData.CardsTween.PathValues;
        }

        public void Subscribe()
        {
            _cardsEventData.CardSpawned += CardsEventDataOnCardSpawned;
        }

        public void Unsubscribe()
        {
            _cardsEventData.CardSpawned -= CardsEventDataOnCardSpawned;
            _tweenerCore.onComplete -= OnComplete;
            _tweenerCore.onWaypointChange -= OnWaypointChange;
        }

        private void CardsEventDataOnCardSpawned(GameObject gameObject)
        {
            _cardTransform = gameObject.transform;
            _cardTransform.position = new Vector3(-4f, -0.8f, _cardTransform.transform.position.z);
            for (int i = 0; i < _pathValues.Length; i++)
            {
                var y = -0.05f * (_xValues[i] * _xValues[i]);
                _pathValues[i] = new Vector3(_xValues[i], y, _cardTransform.transform.position.z);
            }

            _tweenerCore = _cardTransform.transform.DOPath(_pathValues, 5, _pathType);
            _tweenerCore.onComplete += OnComplete;
            _tweenerCore.onWaypointChange += OnWaypointChange;
            _tweenerCore.SetLookAt(_pathValues[6], Vector3.left);
        }

        private void OnWaypointChange(int value)
        {
        }

        private void OnComplete()
        {
            
        }
    }
}