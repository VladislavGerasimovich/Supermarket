using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace DragAndDrop
{
    public class DragAndDropHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask _itemsLayerMask;
        [SerializeField] private Transform _shoppingCart;
        
        public void Perform(Finger finger)
        {
            Ray ray = Camera.main.ScreenPointToRay(finger.screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _itemsLayerMask) == true)
            {
                Debug.Log(hit.collider);
                hit.rigidbody.useGravity = false;
                hit.rigidbody.isKinematic = true;
                hit.transform.SetParent(_shoppingCart);
                hit.transform.localPosition = Vector3.zero;
            }
        }
    }
}