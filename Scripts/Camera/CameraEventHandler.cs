
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class CameraEventHandler : MonoBehaviour
    {
        [SerializeField] private GameEventHandler m_GameEventHandler;
        public static Action<CameraEventHandler> OnLive;
        public Action OnItemToCleanInteract;
        public Action OnClickNextCam, OnClickPreCam;
        public Action OnClickYesForItemToClean;

        private void Awake() => OnLive?.Invoke(this);
        private void OnEnable()
        {
            GameEventHandler.OnLive += SetGameEventHandlerInstance;

            
        }
        private void Start()
        {

        }
        void Subscribe()
        {
            m_GameEventHandler.OnItemCleanInteract += CallbackToCameraManager;
            m_GameEventHandler.OnClickYesForItemToClean += CallbackToCleaningviewCamera;
            m_GameEventHandler.OnClickNextCam += CallbackOfNextToCleaningViewCamera;
            m_GameEventHandler.OnClickPreCam += CallbackOfPreToCleaningViewCamera;
        }

        private void CallbackToCleaningviewCamera() => OnClickYesForItemToClean?.Invoke();

        private void CallbackOfPreToCleaningViewCamera()
        {
            OnClickNextCam?.Invoke();
        }

        private void CallbackOfNextToCleaningViewCamera()
        {
            OnClickPreCam?.Invoke();
        }

        private void CallbackToCameraManager() 
        {
            OnItemToCleanInteract?.Invoke();
        } 

        void Unsubscribe()
        {
            m_GameEventHandler.OnItemCleanInteract -= CallbackToCameraManager;
            m_GameEventHandler.OnClickYesForItemToClean -= CallbackToCleaningviewCamera;
            m_GameEventHandler.OnClickNextCam -= CallbackOfNextToCleaningViewCamera;
            m_GameEventHandler.OnClickPreCam -= CallbackOfPreToCleaningViewCamera;
        }
        private void SetGameEventHandlerInstance(GameEventHandler instance) 
        {
            m_GameEventHandler = instance;
            Subscribe();
        }
        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}

