using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private float _speed;

        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Vector3 forward = ProjectOnPlane(_cameraTransform.forward);
            Vector3 right = ProjectOnPlane(_cameraTransform.right);
            Vector3 playerSpeed = Vector3.zero;

            if (_characterController.isGrounded == true)
            {
                playerSpeed = 
                    forward * _fixedJoystick.Vertical + 
                    right * _fixedJoystick.Horizontal;
            }

            _characterController.Move((playerSpeed * _speed + Physics.gravity) * Time.deltaTime);
        }

        private Vector3 ProjectOnPlane(Vector3 vector)
        {
            return Vector3.ProjectOnPlane(vector, Vector3.up).normalized;
        }
    }
}