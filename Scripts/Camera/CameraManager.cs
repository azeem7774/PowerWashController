using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class CameraManager : MonoBehaviour
    {
        private CameraEventHandler m_CameraEventHandler;
        [SerializeField] private CleaningViewCamerasHandler[] m_CleaningViewCams;
        private void Awake()
        {
            m_CameraEventHandler = GetComponent<CameraEventHandler>();
        }

        private void OnEnable()
        {
            Subscribe();
        }
        void Start()
        {

        }

        void Subscribe()
        {
            m_CameraEventHandler.OnItemToCleanInteract += TurnOnWindowCamera;
        }

        private void TurnOnWindowCamera()
        {
            m_CleaningViewCams[0].gameObject.SetActive(true);
        }

        void Unsubscribe()
        {
            m_CameraEventHandler.OnItemToCleanInteract -= TurnOnWindowCamera;
        }
        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}

