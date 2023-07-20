using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class VFXHandler : MonoBehaviour
    {
        [SerializeField] private GameEventHandler m_GameEventHandler;
        [SerializeField] private GameObject[] m_ParticlesForObjectHighlighting;
        public static Action<VFXHandler> OnAwake;

        private void OnEnable()
        {
            GameEventHandler.OnLive += SetGameEventHandlerInstance;
        }

        private void Start()
        {
            Helper.ToggleGameObjectsWithStartIndex(m_ParticlesForObjectHighlighting, 1, false);
            OnAwake?.Invoke(this);
            Subscribe();
        }

        private void SetGameEventHandlerInstance(GameEventHandler instance) => m_GameEventHandler = instance;

        private void Subscribe()
        {
            m_GameEventHandler.CallbackForVFX += TurnOnParticle;
        }

        private void TurnOnParticle(int index) => Helper.ToggleSingleGameObject(m_ParticlesForObjectHighlighting[index], true);
        void Unsubscribe()
        {
            m_GameEventHandler.CallbackForVFX -= TurnOnParticle;
        }

        private void OnDisable()
        {
            GameEventHandler.OnLive -= SetGameEventHandlerInstance;
            Unsubscribe();
        }
    }

}

