using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TurningArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsInZone { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsInZone = true;
            Debug.Log("true");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsInZone = false;
            Debug.Log("false");
        }
    }
}