using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class ItemManager : MonoBehaviour
    {
        [SerializeField] private Item m_CurrentItem;
        [SerializeField] private bool m_ItemToOffAfterInteract;
        [SerializeField] private ItemEventHandler m_ItemEventHandler;
        public Item CurrentItem => m_CurrentItem;
        private void OnEnable()
        {
            PlayerCollisionManager.GetGameObjectInfoWithAction += SetCurrentInteractible;
            UIManager.OnItemSelectionPanelCloseWithYes += TurnOffCurrentGameObject;
        }

        private void SetCurrentInteractible(GameObject obj)
        {
            m_CurrentItem = obj.GetComponent<Item>();
        }

        private void TurnOffCurrentGameObject()
        {
            m_ItemToOffAfterInteract = m_CurrentItem.ItemToOffAfterInteract;
            Helper.ToggleSingleGameObject(m_CurrentItem.Model, !m_ItemToOffAfterInteract);
            Helper.ToggleSingleGameObject(m_CurrentItem.ParticleEFx, false);
        }

        private void OnDisable()
        {
            PlayerCollisionManager.GetGameObjectInfoWithAction -= SetCurrentInteractible;
            UIManager.OnItemSelectionPanelCloseWithYes -= TurnOffCurrentGameObject;
        }
    }
}

