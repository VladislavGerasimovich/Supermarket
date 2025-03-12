using DragAndDrop;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class MobilePlayerInput : MonoBehaviour
{
    [SerializeField] private RectTransform _joystickTransform;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private DragAndDropHandler _dragAndDropHandler;
    [SerializeField] private float _turnSensitivity;
    [SerializeField] private float _verticalMinAngle;
    [SerializeField] private float _verticalMaxAngle;

    private Finger _movementFinger;
    private Vector2 _startPosition;
    private float _cameraAngle = 0;

    private void Awake()
    {
        _cameraAngle = _cameraTransform.localEulerAngles.x;
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += OnFingerDown;
        ETouch.Touch.onFingerUp += OnFingerUp;
        ETouch.Touch.onFingerMove += OnFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= OnFingerDown;
        ETouch.Touch.onFingerUp -= OnFingerUp;
        ETouch.Touch.onFingerMove -= OnFingerMove;
        EnhancedTouchSupport.Disable();
    }

    public void OnFingerMove(Finger finger)
    {
        if (finger == _movementFinger)
        {
            Vector2 handlerPosition;
            ETouch.Touch currentTouch = finger.currentTouch;
            handlerPosition = (currentTouch.screenPosition - _startPosition).normalized * Time.deltaTime * _turnSensitivity;
            _cameraAngle -= handlerPosition.y;
            _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
            _cameraTransform.localEulerAngles = Vector3.right * _cameraAngle;
            transform.Rotate(Vector3.up * handlerPosition.x);
            _startPosition = currentTouch.screenPosition;
        }
    }

    public void OnFingerUp(Finger finger)
    {
        if (finger == _movementFinger)
        {
            _movementFinger = null;
        }
    }

    public void OnFingerDown(Finger finger)
    {
        if (_movementFinger == null)
        {
            _dragAndDropHandler.Perform(finger);

            if (_joystickTransform.rect.size.x < finger.screenPosition.x || _joystickTransform.rect.size.y < finger.screenPosition.y)
            {
                _movementFinger = finger;
                _startPosition = finger.screenPosition;
            }
        }
    }
}