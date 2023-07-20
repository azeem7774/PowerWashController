using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class CameraChanger : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera m_TPSCamera;
        [SerializeField] private CinemachineVirtualCamera m_FPSCamera;
        private void OnEnable()
        {
            UIManager.OnItemSelectionPanelCloseWithYes += SwithToTPS;
            PlayerCollisionManager.OnTriggerWithInteractable += SwitchToFPS;
        }
        void Start()
        {

        }
        private void SwithToTPS()
        {
            SwitchCamera(m_TPSCamera, m_FPSCamera);
        }


        private void SwitchToFPS()
        {
            SwitchCamera(m_FPSCamera, m_TPSCamera);
        }

        private void SwitchCamera(CinemachineVirtualCamera cam1, CinemachineVirtualCamera cam2)
        {
            cam1.Priority = 100;
            cam2.Priority = 1;
        }
        private void OnDisable()
        {
            UIManager.OnItemSelectionPanelCloseWithYes -= SwithToTPS;
            PlayerCollisionManager.OnTriggerWithInteractable -= SwitchToFPS;
        }
    }
}

