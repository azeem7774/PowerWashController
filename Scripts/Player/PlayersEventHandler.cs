using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class PlayersEventHandler : MonoBehaviour
    {
        public static Action<PlayersEventHandler> OnAwake;
        public Action<int> OnReachingCheckPoint;
        public Action OnItemSelected;
        public Action OnItemToCleanInteract;
        public Action<ItemToClean> OnTriggerWithItemToClean;
        [SerializeField] private GameEventHandler m_GameEventHandler;
        private ItemInHand m_ItemInHand;
        private PlayerCollisionManager m_PlayerCollisionManager;
        private ItemToClean m_ItemToClean;
        //private void Awake() => OnAwake?.Invoke(this );

        private void OnEnable()
        {
            GameEventHandler.OnLive += SetGameEventHandlerInstance;
        }

        private void Start()
        {
            m_ItemInHand = GetComponent<ItemInHand>();
            m_PlayerCollisionManager = GetComponent<PlayerCollisionManager>();
            OnAwake?.Invoke(this);
            StartCoroutine(WaitBeforeBinding());
        }

        private IEnumerator WaitBeforeBinding()
        {
            yield return new WaitForSeconds(0.1f);
            Subscribe();
        }
        private void SetGameEventHandlerInstance(GameEventHandler intance) => m_GameEventHandler = intance;

        private void TurnOnItemInHandOfPlayer(Items itemEnum)
        {
            m_ItemInHand.TrunOnItemInHand((int)itemEnum);
        }

        private void Subscribe()
        {
            m_GameEventHandler.OnGettingItemEnum += TurnOnItemInHandOfPlayer;
            m_GameEventHandler.OnItemSelected += CallbackToPlayerPositionHandler;
            m_GameEventHandler.OnItemCleanInteract += CallbackToPlayerAnimatorController;
            m_PlayerCollisionManager.OnTriggerInteractable += UpdateCheckPoint;
            m_PlayerCollisionManager.OnTriggerWithItemToClean += CallbackToGameEventHandler;

        }

        private void CallbackToPlayerAnimatorController() 
        {
            OnItemToCleanInteract?.Invoke();
        } 

        private void CallbackToGameEventHandler(ItemToClean instance) => OnTriggerWithItemToClean?.Invoke(instance);

        private void CallbackToPlayerPositionHandler() => OnItemSelected?.Invoke();


        //?? shouldn't it be the part of PrefManager class? 
        private void UpdateCheckPoint()
        {
            int currentCheckPoint = PrefManager.PlayerCheckPoint;
            currentCheckPoint++;
            PrefManager.PlayerCheckPoint = currentCheckPoint;
            OnReachingCheckPoint?.Invoke(currentCheckPoint);
        }


        private void Unsubscribe()
        {
            m_GameEventHandler.OnGettingItemEnum -= TurnOnItemInHandOfPlayer;
            m_GameEventHandler.OnItemSelected -= CallbackToPlayerPositionHandler;
            m_PlayerCollisionManager.OnTriggerInteractable -= UpdateCheckPoint;
            m_PlayerCollisionManager.OnTriggerWithItemToClean -= CallbackToGameEventHandler;
        }
        private void OnDisable()
        {
            GameEventHandler.OnLive -= SetGameEventHandlerInstance;
            Unsubscribe();
        }
    }
}

