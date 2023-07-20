using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN
{
    public class GameEventHandler : MonoBehaviour
    {
        [SerializeField] private UIManager m_UIManager;
        [SerializeField] private PlayersEventHandler m_PlayerEventHandler;
        [SerializeField] private ItemEventHandler m_ItemEventHandler;
        [SerializeField] private VFXHandler m_VFXHandler;
        [SerializeField] private LevelEventHandler m_LevelEventHandler;

        public static Action<GameEventHandler> OnLive;
        public Action OnItemSelected;
        public Action<Items> OnGettingItemEnum;
        public Action<int> CallbackForVFX;
        public Action OnItemCleanInteract;
        public Action OnClickNextCam, OnClickPreCam;
        public Action OnClickYesForItemToClean;
        public Action OnCleaningNearToEnd;

        private void OnEnable()
        {
            SubscribeByStaticCalls();
        }

        private void Start()
        {
            OnLive?.Invoke(this);

            StartCoroutine(WaitBeforeBinding());
        }
        private IEnumerator WaitBeforeBinding()
        {
            yield return new WaitForSeconds(0.1f);
            Subscribe();
        }
        #region Static Calls
        private void SubscribeByStaticCalls()
        {
            UIManager.OnAwake += SetUIInstance;
            PlayersEventHandler.OnAwake += SetPlayerEventHandlerInstance;
            ItemEventHandler.OnAwake += SetItemEventHandlerInstance;
            VFXHandler.OnAwake += SetVFXHandlerInstance;
            CleaningProcess.OnCleaningNearToEnd += CallbackToUIManager;
        }

        private void CallbackToUIManager() => OnCleaningNearToEnd?.Invoke();

        private void SetPlayerEventHandlerInstance(PlayersEventHandler instance) => m_PlayerEventHandler = instance;

        private void SetUIInstance(UIManager instance) => m_UIManager = instance;

        private void SetItemEventHandlerInstance(ItemEventHandler instance) => m_ItemEventHandler = instance;

        private void SetVFXHandlerInstance(VFXHandler instance) => m_VFXHandler = instance;

        private void UnsubscribeByStaticCalls()
        {
            UIManager.OnAwake -= SetUIInstance;
            PlayersEventHandler.OnAwake -= SetPlayerEventHandlerInstance;
            ItemEventHandler.OnAwake -= SetItemEventHandlerInstance;
            VFXHandler.OnAwake -= SetVFXHandlerInstance;
            CleaningProcess.OnCleaningNearToEnd -= CallbackToUIManager;
        }
        #endregion
        private void Subscribe()
        {
            m_UIManager.OnItemSelect += SelectItem;
            m_UIManager.OnClickNextCam += CallbackOfNextToCameraHandler;
            m_UIManager.OnClickPreCam += CallbackOfPreToCameraHandler;
            m_UIManager.OnItemToCleanInteract += CallbackForTurningOnCamera;
            m_ItemEventHandler.OnItemSelected += CallbackToPlayerWithEnum;
            m_ItemEventHandler.OnItemCleanInteract += CallbackToCameraHandler;
            m_PlayerEventHandler.OnReachingCheckPoint += CallBackToVFXHandler;
            
        }

        private void CallbackOfNextToCameraHandler()
        {
            OnClickNextCam?.Invoke();
        }

        private void CallbackOfPreToCameraHandler()
        {
            OnClickPreCam?.Invoke();
        }

        private void CallbackToCameraHandler()
        {
            OnItemCleanInteract?.Invoke();
        } 

        private void SelectItem() => OnItemSelected?.Invoke();

        private void CallbackToPlayerWithEnum(Items itemEnum) => OnGettingItemEnum?.Invoke(itemEnum);

        private void CallBackToVFXHandler(int index) => CallbackForVFX?.Invoke(index);
        private void CallbackForTurningOnCamera() => OnClickYesForItemToClean?.Invoke();
        private void Unsubscribe()
        {
            m_UIManager.OnItemSelect -= SelectItem;
            m_UIManager.OnClickNextCam -= CallbackOfNextToCameraHandler;
            m_UIManager.OnClickPreCam -= CallbackOfPreToCameraHandler;
            m_UIManager.OnItemToCleanInteract -= CallbackForTurningOnCamera;
            m_ItemEventHandler.OnItemSelected -= CallbackToPlayerWithEnum;
            m_ItemEventHandler.OnItemCleanInteract -= CallbackToCameraHandler;
            m_PlayerEventHandler.OnReachingCheckPoint -= CallBackToVFXHandler;
        }

        

        private void OnDisable()
        {
            UnsubscribeByStaticCalls();
            Unsubscribe();
        }
    }
}

