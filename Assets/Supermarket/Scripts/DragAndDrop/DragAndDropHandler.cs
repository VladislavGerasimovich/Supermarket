using Items;
using ShoppingCart;
using UI;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace DragAndDrop
{
    public class DragAndDropHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask _itemsLayerMask;
        [SerializeField] private Cart _shoppingCart;
        [SerializeField] private DropButton _dropButton;
        
        public void Perform(Finger finger)
        {
            Ray ray = Camera.main.ScreenPointToRay(finger.screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _itemsLayerMask) == true)
            {
                if(_shoppingCart.HasItem == false)
                {
                    Item itemPosition = hit.transform.GetComponent<Item>();
                    _shoppingCart.TakeItem(itemPosition);
                    itemPosition.SetPosition(hit, _shoppingCart.transform);
                    _dropButton.SetStatus(true);
                }
            }
        }
    }
}