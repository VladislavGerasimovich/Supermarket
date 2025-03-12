using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Game.Player.Movement
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] public Joystick _joystick;

        public bool IsCan { get; private set; }
        public Vector2 MovementAmount { get; private set; }

        public void SetMovementPosition(Vector2 movementAmount)
        {
            MovementAmount = movementAmount;
        }

        public virtual void OnFingerMove(Finger finger) { }

        public virtual void OnFingerUp(Finger finger) { }

        public virtual void OnFingerDown(Finger finger) { }
    }
}