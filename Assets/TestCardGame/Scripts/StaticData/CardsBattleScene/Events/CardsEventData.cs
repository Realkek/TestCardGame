using System;
using Unity.VisualScripting;
using UnityEngine;

namespace TestCardGame.Scripts.StaticData.CardsBattleScene.Events
{
    [CreateAssetMenu(menuName = "StaticData/Game/EventsData/CardsBattle/CardsEventData",
        fileName = "CardsEventData")]
    public class CardsEventData : ScriptableObject
    {
        public event Action CardSpawned;
        public event Action MaxNumberOfCardsReached;
        public event Action CardSpawnInitiated;

        public void TriggerMaxNumberOfCardsReached() => MaxNumberOfCardsReached?.Invoke();
        public void TriggerCardSpawnInitiated() => CardSpawnInitiated?.Invoke();
        public void TriggerCardSpawned() => CardSpawned?.Invoke();
    }
}