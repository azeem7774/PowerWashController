using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PWN
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator m_PlayerAnimator;
        [SerializeField] private int m_PlayerNormalSpeed;
        [SerializeField] private int m_PlayerMovementSpeed;
        [SerializeField] private PlayersEventHandler m_PlayerEventHandler;
        private void OnEnable()
        {
            ScreenTouchInput.OnScreenPointerDown += IncreaseAnimatorSpeed;
            ScreenTouchInput.OnScreenPointerUp += NormalizeAnimatorSpeed;
            Subscribe();
        }
        void Start()
        {

            if (m_PlayerAnimator == null) m_PlayerAnimator = GetComponent<Animator>();
            NormalizeAnimatorSpeed();
        }

        private void IncreaseAnimatorSpeed()
        {
            SetAnimatorSpeed(m_PlayerMovementSpeed);
        }
        private void NormalizeAnimatorSpeed()
        {
            SetAnimatorSpeed(m_PlayerNormalSpeed);
        }
        public void SetAnimatorSpeed(int speed)
        {
            m_PlayerAnimator.speed = speed;
        }
        private void Subscribe()
        {
            m_PlayerEventHandler = GetComponent<PlayersEventHandler>();
            m_PlayerEventHandler.OnItemToCleanInteract += SetAnimatorSpeedToZero;        
        }

        private void SetAnimatorSpeedToZero()
        {
            SetAnimatorSpeed(0);
        }

        private void Unsubscribe()
        {
            m_PlayerEventHandler.OnItemToCleanInteract -= SetAnimatorSpeedToZero;
        }
        private void OnDisable()
        {
            ScreenTouchInput.OnScreenPointerDown -= IncreaseAnimatorSpeed;
            ScreenTouchInput.OnScreenPointerUp -= NormalizeAnimatorSpeed;
            Unsubscribe();
        }
    }
}

