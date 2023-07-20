using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class ItemEventHandler : MonoBehaviour
    {
        public static Action<ItemEventHandler> OnAwake;
        public Action<Items> OnItemSelected;
        public Action OnItemCleanInteract;
        [SerializeField] private GameEventHandler m_GameEventHandler;
        [SerializeField] private ItemManager m_ItemManager;
        [SerializeField] private ItemToClean[] m_ItemsToClean;
        private Items m_currentItem;
        private void OnEnable()
        {
            GameEventHandler.OnLive += SetGameEventHandlerInstance;
        }

        private void Start()
        {
            OnAwake?.Invoke(this);
            m_ItemManager = GetComponent<ItemManager>();
        }

        private void SetGameEventHandlerInstance(GameEventHandler instance)
        {
            m_GameEventHandler = instance;
            Subscribe();
        }

        private void Subscribe()
        {
            m_GameEventHandler.OnItemSelected += SendCallbackToGameEventHandlerWithItemEnum;
            m_ItemsToClean[0].OnItemCleanInteract += OnItemToCleanInteract;
        }

        private void OnItemToCleanInteract() 
        {
            OnItemCleanInteract?.Invoke();
        } 

        private void SendCallbackToGameEventHandlerWithItemEnum()
        {
            m_currentItem = m_ItemManager.CurrentItem.Items;
            OnItemSelected?.Invoke(m_currentItem);
        }

        private void OnDisable()
        {
            GameEventHandler.OnLive -= SetGameEventHandlerInstance;
        }
    }
}

