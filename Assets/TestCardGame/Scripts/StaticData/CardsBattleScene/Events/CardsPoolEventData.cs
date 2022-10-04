using System;
using UnityEngine;

namespace TestCardGame.Scripts.StaticData.CardsBattleScene.Events
{
    [CreateAssetMenu(menuName = "Game/StaticData/CardsBattle/EventsData/CardsPoolEventData",
        fileName = "CardsPoolEventData")]
    public class CardsPoolEventData : ScriptableObject
    {
        public event Action MaxNumberOfCardsReached;
        public event Action CardsSpawnInitiated;
        public void TriggerMaxNumberOfCardsReached() => MaxNumberOfCardsReached?.Invoke();
        public void TriggerCardSpawnInitiated() => CardsSpawnInitiated?.Invoke();
    }
}