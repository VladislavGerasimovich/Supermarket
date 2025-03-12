using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

namespace Items
{
    [RequireComponent(typeof(Rigidbody))]
    public class Item : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetPosition(RaycastHit hit, Transform shoppingCart)
        {
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
            transform.SetParent(shoppingCart);
            transform.localPosition = Vector3.zero;
        }

        public void Fall(Vector3 direction)
        {
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(direction * _speed);
        }
    }
}