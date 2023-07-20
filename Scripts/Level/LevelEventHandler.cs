using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class LevelEventHandler : MonoBehaviour
    {
        [SerializeField] private GameEventHandler m_GameEventHandler;
        public static Action<LevelEventHandler> OnLive;
        
       
        private void OnEnable()
        {
            GameEventHandler.OnLive += SetGameEventHandlerInstance;
        }

        private void SetGameEventHandlerInstance(GameEventHandler instance)
        {
            m_GameEventHandler = instance;
            Subscribe();
        }

        private void Subscribe()
        {

        }
    }
}

