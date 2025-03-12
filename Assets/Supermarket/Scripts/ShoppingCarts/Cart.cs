using Items;
using UnityEngine;

namespace ShoppingCart
{
    public class Cart : MonoBehaviour
    {
        [SerializeField] private Transform _itemsContainer;

        private Item _item;

        public bool HasItem { get; private set; }

        public void TakeItem(Item item)
        {
            HasItem = true;
            _item = item;
        }

        public void ThrowItem()
        {
            HasItem = false;
            _item.Fall(transform.forward);
            _item.transform.SetParent(_itemsContainer);
        }
    }
}