using System;
using UnityEngine;

namespace TestCardGame.Scripts.StaticData.Events
{
    [CreateAssetMenu(menuName = "Game/StaticData/EventsData/SelectObjectEventData",
        fileName = "SelectObjectEventData")]
    public class SelectObjectEventData : ScriptableObject
    {
        public event Action<GameObject> ObjectSelected;

        public void TriggerSelectObject(GameObject gameObject)
        {
            ObjectSelected?.Invoke(gameObject);
        }
    }
}