using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _01.Scripts.Player
{
    [CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
    public class PlayerInputSO : ScriptableObject,Controls.IPlayerActions
    {
        [SerializeField] private LayerMask whatIsGround;
    
        public event Action OnXCommandPressed;
        public event Action OnYCommandPressed;
        public event Action OnACommandPressed;
        public event Action OnBCommandPressed;
    
        public Vector2 MovementKey { get; private set; }
        private Controls _controls;
    
        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            MovementKey = context.ReadValue<Vector2>();
        }
    }
}
