using System;
using UnityEngine;

namespace TestCardGame.Scripts.StaticData.Events
{
    [CreateAssetMenu(menuName = "StaticData/Game/EventsData/CardSelected",
        fileName = "CardSelectedEventData")]
    public class PlayerInputKeysEventData : ScriptableObject
    {
        public event Action<GameObject> CardSelected;
        
        
        public void OnCardSelected(GameObject gameObject)
        {
            CardSelected?.Invoke(gameObject);
        }
    }
}