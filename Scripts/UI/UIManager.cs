using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PWN 
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameEventHandler m_GameEventHandler;

        [Header("UI Panels")]
        [Space(20)]
        [SerializeField] private ItemSelectionPanel m_ItemSelectionPanel;
        [SerializeField] private ScreenTouchInput m_TouchPad;
        [SerializeField] private LoadingScreen m_LoadingScreen;
        [SerializeField] private CameraChangingUI m_CameraChangingUI;

        private WaitForSeconds wait;
        public static Action OnItemSelectionPanelCloseWithYes;
        public static Action<UIManager> OnAwake;
        public Action OnItemToCleanInteract;
        public Action OnClickNextCam, OnClickPreCam;
        public Action OnCleaningNearToEnd;

        public Action OnItemSelect;
        // private void Awake() => OnAwake?.Invoke(this);

        private void OnEnable()
        {
            PlayerCollisionManager.OnTriggerWithInteractable += OpenItemSelectionPanel;
            GameEventHandler.OnLive += SetGameEventHandlerInstance;
            
        }



        private void Start()
        {
            OnAwake?.Invoke(this);
            m_ItemSelectionPanel.gameObject.SetActive(false);
            m_TouchPad.gameObject.SetActive(true);
            wait = new WaitForSeconds(3);
        }

        private void Subscribe()
        {
            m_GameEventHandler.OnCleaningNearToEnd += CallbackToCameraChangingUI;
            m_ItemSelectionPanel.OnClickYes += CloseItemSelectionPanelWithYes;
            m_LoadingScreen.OnLoadingComplete += OnCompleteLoading;
            m_CameraChangingUI.OnClickNextCam += CallbackOfNextToGameEventHandler;
            m_CameraChangingUI.OnClickPreCam += CallbackToPreToGameEventHandler;
        }

        private void CallbackToCameraChangingUI() => OnCleaningNearToEnd?.Invoke();

        private void SetGameEventHandlerInstance(GameEventHandler instance)
        {
            m_GameEventHandler = instance;
            Subscribe();
        }
        private void CallbackToPreToGameEventHandler()
        {
            OnClickNextCam?.Invoke();
        }

        private void CallbackOfNextToGameEventHandler()
        {
            OnClickPreCam?.Invoke();
        }

        private void OnCompleteLoading()
        {
            Helper.SwitchBetweenTwoGameObjects(m_TouchPad.gameObject,m_LoadingScreen.gameObject);
        }

        private void OpenItemSelectionPanel()
        {
            Helper.ToggleSingleGameObject(m_TouchPad.gameObject, false);
            StartCoroutine(TurnOnITemSelectionPanel());
        }

        private void CloseItemSelectionPanelWithYes()
        {
            Helper.SwitchBetweenTwoGameObjects(m_LoadingScreen.gameObject, m_ItemSelectionPanel.gameObject);
            OnItemSelectionPanelCloseWithYes?.Invoke();
            OnItemSelect?.Invoke();
            if (GameRunTimeRepository.CurrentItemToClean != null)
            {
                TurnOnCameraChangingUI();
                OnItemToCleanInteract?.Invoke();
                GameRunTimeRepository.CurrentItemToClean = null; //?? patch- this line shouldn't be written there
                m_TouchPad.gameObject.SetActive(false);
            }
            else
            {
                m_TouchPad.gameObject.SetActive(true);
            }
        }
        private void TurnOnCameraChangingUI() => m_CameraChangingUI.gameObject.SetActive(true);
        private IEnumerator TurnOnITemSelectionPanel()
        {
            yield return wait;
            Helper.ToggleSingleGameObject(m_ItemSelectionPanel.gameObject, true);
        }
        private void Unsubscribe()
        {
            m_GameEventHandler.OnCleaningNearToEnd -= CallbackToCameraChangingUI;
            m_ItemSelectionPanel.OnClickYes -= CloseItemSelectionPanelWithYes;
            m_LoadingScreen.OnLoadingComplete -= OnCompleteLoading;
            m_CameraChangingUI.OnClickNextCam -= CallbackOfNextToGameEventHandler;
            m_CameraChangingUI.OnClickPreCam -= CallbackToPreToGameEventHandler;
        }
        

        private void OnDisable()
        {
            PlayerCollisionManager.OnTriggerWithInteractable -= OpenItemSelectionPanel;
            GameEventHandler.OnLive -= SetGameEventHandlerInstance;
            Unsubscribe();
        }
    }
}

