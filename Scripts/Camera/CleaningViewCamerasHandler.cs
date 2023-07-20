using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class CleaningViewCamerasHandler : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera[] m_Cams;
        private int m_CamIndex =0;
        [SerializeField] private CameraEventHandler m_CameraEventHandler;
        public static Action OnLive;
        private void OnEnable() 
        {
            CameraEventHandler.OnLive += SetInstanceOfCameraEventHandler;
            OnLive?.Invoke();
            Subscribe();
        }

        private void SetInstanceOfCameraEventHandler(CameraEventHandler instance)
        {
            m_CameraEventHandler = instance;
            Subscribe();
        }

        void Start()
        {
            //m_Cams[m_CamIndex].Priority = 100;
        }

        private void TurnOnCamera()
        {
            m_Cams[m_CamIndex].Priority = 100;
        }
        private void Subscribe()
        {
            m_CameraEventHandler.OnClickYesForItemToClean += TurnOnCamera;
            m_CameraEventHandler.OnClickNextCam += NextCamera;
            m_CameraEventHandler.OnClickPreCam += PreviousCamera;
        }

        private void PreviousCamera()
        {
            SetPriortyOfCams(0);
            m_CamIndex = (m_CamIndex + 1) % m_Cams.Length;
            m_Cams[m_CamIndex].Priority = 100;
        }

        private void NextCamera()
        {
            SetPriortyOfCams(0);
            m_CamIndex = (m_CamIndex + m_Cams.Length - 1) % m_Cams.Length;
            m_Cams[m_CamIndex].Priority = 100;
        }

        void SetPriortyOfCams(int priorty)
        {
            for (int i = 0; i < m_Cams.Length; i++)
                m_Cams[i].Priority = priorty;
        }

        private void Unsubscribe()
        {
            m_CameraEventHandler.OnClickYesForItemToClean -= TurnOnCamera;
            m_CameraEventHandler.OnClickNextCam -= NextCamera;
            m_CameraEventHandler.OnClickPreCam -= PreviousCamera;
        }
        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}

