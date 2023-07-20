using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class PlayerWatchBehavior : MonoBehaviour
    {
        [SerializeField] private Transform m_EyeTransorm;
        [SerializeField] private CinemachineVirtualCamera m_PlayerEyeCamera;
        private PlayerCollisionManager m_PlayerCollisionManager;
        private Item m_Item;
        private void OnEnable()
        {

        }

        void Start()
        {
            m_PlayerCollisionManager = GetComponent<PlayerCollisionManager>();
            PlayerCollisionManager.GetGameObjectInfoWithAction += WatchAhead;
        }

        private void WatchAhead(GameObject go)
        {
            SetItem(go);
            m_PlayerEyeCamera.transform.SetParent(m_EyeTransorm);
            m_PlayerEyeCamera.LookAt = m_Item.Model.transform;
            m_PlayerEyeCamera.Follow = m_Item.Model.transform;
            m_PlayerEyeCamera.Priority = 100;
        }
        private void SetItem(GameObject go) => m_Item = go.GetComponent<Item>();
        private void OnDisable()
        {
            PlayerCollisionManager.GetGameObjectInfoWithAction -= WatchAhead;
        }
    }
}

