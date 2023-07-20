using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PWN
{
    public class CameraChangingUI : MonoBehaviour
    {
        [SerializeField] private UIManager m_UIManager;
        [SerializeField] private Button m_Next;
        [SerializeField] private Button m_Previous;
        [SerializeField] private Button m_CompleteCleaning;
        [SerializeField] private GameObject m_CompleteCleaningUI;

        public Action OnClickNextCam, OnClickPreCam, OnCompleteCleaning;
        private void Awake() => m_UIManager = GetComponentInParent<UIManager>();
        private void OnEnable()
        {
            m_UIManager.OnCleaningNearToEnd += TurnOnCompleteCleaningUI;
        }

        

        private void Start()
        {
            Helper.ToggleSingleGameObject(m_CompleteCleaningUI, false);
            m_Next.onClick.AddListener(OnClickNext);
            m_Previous.onClick.AddListener(OnClickPrevious);
            m_CompleteCleaning.onClick.AddListener(OnClickCompleteCleaning);
        }

        private void TurnOnCompleteCleaningUI() => Helper.ToggleSingleGameObject(m_CompleteCleaningUI, true);
        private void OnClickCompleteCleaning() 
        {
            Helper.ToggleSingleGameObject(m_CompleteCleaningUI, false);
            OnCompleteCleaning?.Invoke();
        } 

        private void OnClickPrevious() => OnClickNextCam?.Invoke();

        private void OnClickNext() => OnClickPreCam?.Invoke();
        private void OnDisable()
        {

        }
    }
}

