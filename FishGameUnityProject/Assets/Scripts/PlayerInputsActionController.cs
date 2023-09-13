using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Game.Character
{
    public class PlayerInputsActionController : MonoBehaviour
    {
        [SerializeField] InputEvent OnJumpButtonPressed;
        [SerializeField] InputEvent OnInteractButtonPressed;
        Vector2 m_moveInputDir;
        public Vector2 m_MoveInputDir => m_moveInputDir;

        private void Update()
        {
            OnJumpButtonPressed.Update();
            OnInteractButtonPressed.Update();
        }

        public void SetMoveDir(InputAction.CallbackContext _action)
        {
            m_moveInputDir = _action.ReadValue<Vector2>();
        }

        public void JumpInput(InputAction.CallbackContext _action)
        {
            if (_action.performed)
            {
                OnJumpButtonPressed.Pressed();
            }
        }

        public void InteractInput(InputAction.CallbackContext _action)
        {
            if (_action.performed)
            {
                OnInteractButtonPressed.Pressed();
            }
        }
    }

    [System.Serializable]
    public class InputEvent
    {
        [SerializeField] UnityEvent OnInputPressed;
        [SerializeField, Min(0.01f)] float m_timer = 0.01f;
        float m_currentTimer = 0;

        public void Update()
        {
            if (m_currentTimer <= 0f) return;

            m_currentTimer -= Time.deltaTime;
            OnInputPressed?.Invoke();
        }

        public void Pressed()
        {
            m_currentTimer = m_timer;
        }
    }
}