using System;
using UnityEngine;

namespace TestCardGame.Scripts.StaticData.Events
{
    [CreateAssetMenu(menuName = "StaticData/Game/EventsData/SelectObjectEventData",
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