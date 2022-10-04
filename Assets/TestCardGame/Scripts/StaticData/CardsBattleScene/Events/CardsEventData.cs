using System;
using UnityEngine;

namespace TestCardGame.Scripts.StaticData.CardsBattleScene.Events
{
    [CreateAssetMenu(menuName = "Game/StaticData/CardsBattle/EventsData/CardsEventData",
        fileName = "CardsEventData")]
    public class CardsEventData : ScriptableObject
    {
        public event Action<GameObject> CardSpawned;
        public void TriggerCardSpawned(GameObject gameObject) => CardSpawned?.Invoke(gameObject);
    }
}