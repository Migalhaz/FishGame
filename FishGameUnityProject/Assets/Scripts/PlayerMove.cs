using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character
{
    [RequireComponent(typeof(PlayerInputsActionController))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        [Header("Player Components")]
        [SerializeField, AutoGetComponent(typeof(PlayerInputsActionController))] PlayerInputsActionController m_playerInputActions;
        [SerializeField, AutoGetComponent(typeof(Rigidbody2D))] Rigidbody2D m_rig;

        [Header("Move Settings")]
        [SerializeField, Min(0)] float m_moveSpeed;
        Vector2 m_moveDir;


        [Header("Jump Settings")]
        [SerializeField, Min(0)] float m_jumpForce;
        Vector2 m_jumpDir;
        bool m_onGround;
        
        void Update()
        {
            SetInputs();            
        }
        void FixedUpdate()
        {
            Move();
        }

        void SetInputs()
        {
            m_moveDir.Set(m_playerInputActions.m_MoveInputDir.x * m_moveSpeed, m_rig.velocity.y);
            m_jumpDir.Set(m_rig.velocity.x, m_jumpForce);
        }

        void Move()
        {
            m_rig.velocity = m_moveDir;
        }

        public void Jump()
        {
            if (!m_onGround) return;
            m_rig.velocity = m_jumpDir;
        }
        
        public void SetOnGround(bool newValue)
        {
            m_onGround = newValue;
        }
    }
}